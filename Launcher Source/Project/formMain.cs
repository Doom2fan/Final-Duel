﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace Launcher {
    public partial class formMain : Form {
        public formMain () {
            InitializeComponent ();
        }

        private void buttonDisPath_Click (object sender, EventArgs e) {
            if (openFileDialogDisPath.ShowDialog () == DialogResult.OK)
                textBoxDisPath.Text = openFileDialogDisPath.FileName;
        }

        private void buttonPK3Path_Click (object sender, EventArgs e) {
            if (openFileDialogPK3Path.ShowDialog () == DialogResult.OK)
                textBoxPK3Path.Text = openFileDialogPK3Path.FileName;
        }

        private void buttonIWADPath_Click (object sender, EventArgs e) {
            if (folderBrowserDialogIWADPath.ShowDialog () == DialogResult.OK)
                textBoxIWADPath.Text = folderBrowserDialogIWADPath.SelectedPath;
        }

        private void textBoxIWADPath_TextChanged (object sender, EventArgs e) {
            Config.IWADPath = textBoxIWADPath.Text;
            comboBoxIWAD.BeginUpdate ();
            comboBoxIWAD.Items.Clear ();
            if (File.Exists (Config.IWADPath + "\\doom.wad"))
                comboBoxIWAD.Items.Add ("Doom");
            if (File.Exists (Config.IWADPath + "\\bfgdoom.wad"))
                comboBoxIWAD.Items.Add ("Doom BFG Edition");
            if (File.Exists (Config.IWADPath + "\\doomu.wad"))
                comboBoxIWAD.Items.Add ("Ultimate Doom");
            if (File.Exists (Config.IWADPath + "\\doom2.wad"))
                comboBoxIWAD.Items.Add ("Doom 2");
            if (File.Exists (Config.IWADPath + "\\bfgdoom2.wad"))
                comboBoxIWAD.Items.Add ("Doom 2 BFG Edition");
            if (File.Exists (Config.IWADPath + "\\tnt.wad"))
                comboBoxIWAD.Items.Add ("TNT");
            if (File.Exists (Config.IWADPath + "\\plutonia.wad"))
                comboBoxIWAD.Items.Add ("Plutonia");
            comboBoxIWAD.EndUpdate ();
        }

        private void checkBoxMap_CheckedChanged (object sender, EventArgs e) {
            if (checkBoxMap.Checked) {
                numericUpDownMap.Visible = false;
                textBoxMap.Visible = true;
                Config.MapNameOn = true;
            } else {
                textBoxMap.Visible = false;
                numericUpDownMap.Visible = true;
                Config.MapNameOn = false;
            }
        }

        private void checkBoxClass_CheckedChanged (object sender, EventArgs e) {
            if (checkBoxClass.Checked) {
                textBoxClass.Visible = false;
                numericUpDownClass.Visible = true;
                Config.ClassNumberOn = true;
            } else {
                numericUpDownClass.Visible = false;
                textBoxClass.Visible = true;
                Config.ClassNumberOn = false;
            }
        }

        private void buttonCheckUpdates_Click (object sender, EventArgs e) // Directory.GetCurrentDirectory()
        {
            toolStripStatusLabel.Text = "Checking for updates...";
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;

            if (radioButtonVersionRelease.Checked) {
                if (radioButtonUpdateLauncher.Checked) {
                } else {
                    if (!File.Exists (Config.FDPath)) {
                        toolStripStatusLabel.Text = "Ready";
                        toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                        if (Config.FDPath == string.Empty)
                            if (MessageBox.Show ("PK3 path not set.\nDo you want to download the file to the launcher's folder?", "PK3 path not set", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                                //goto DownloadFD;
                            } else
                                return;
                        MessageBox.Show ("Invalid path.\nMake sure you set the path to the PK3 file in the \"Basic\" tab", "Invalid file path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Uri md5Hashuri = new Uri ("http://localhost/UploadedInfo.txt");
                    string tempPath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location) + "\\Temp\\ModUpdate";

                    using (WebClient UpdaterGetNewestFDRelease = new WebClient ()) {
                        UpdaterGetNewestFDRelease.DownloadFileAsync (md5Hashuri, tempPath + "\\UploadedVersion.txt");
                        UpdaterGetNewestFDRelease.DownloadFileCompleted += UpdaterGetNewestFDRelease_DownloadFileCompleted;
                    }
                }
            } else {
            }
        }

        private void UpdaterGetNewestFDRelease_DownloadFileCompleted (object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            string tempPath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location) + "\\Temp\\ModUpdate";
            //string zipName = "\\Final_Duel_Stable.zip";
            string md5Hash = string.Empty;

            Directory.CreateDirectory (tempPath);
            using (var md5 = MD5.Create ()) {
                using (var stream = File.OpenRead (Config.FDPath)) {
                    byte[] Hash = md5.ComputeHash (stream);
                    for (int i = 0; i < (Hash.Count () - 1); i++)
                        md5Hash += Hash.ElementAt (i);
                }
            }

            string[] UploadedVersion = File.ReadAllLines (tempPath + "\\UploadedVersion.txt");
            ExtractZip (Config.FDPath, tempPath, "FDVERSION.txt");
            foreach (string line in UploadedVersion) {
                if (!File.Exists (tempPath + "\\FDVERSION.txt"))
                    return;
                string[] FDVersion = File.ReadAllLines (tempPath + "\\FDVERSION.txt");
                string[] s = line.Split ('=');
                if (s[0].Equals ("md5")) {
                    if (s[1].Equals (md5Hash)) {
                        MessageBox.Show ("You have the latest release.", "No new updates", MessageBoxButtons.OK, MessageBoxIcon.None);
                        return;
                    }
                } else {
                    foreach (string line2 in FDVersion) {
                        string[] s2 = line.Split ('=');
                        if (s2[0].Equals ("ver")) {
                            if (s2[1].Equals (s[1])) {
                                MessageBox.Show ("You have the latest release.", "No new updates", MessageBoxButtons.OK, MessageBoxIcon.None);
                                return;
                            }
                        }
                    }
                }
            }
            DownloadFDRelease ();
        }
        
        private void DownloadFDRelease () {

        }

        private void client_DownloadProgressChanged (object sender, DownloadProgressChangedEventArgs e) {
            toolStripStatusLabel.ForeColor = Color.FromKnownColor (KnownColor.ControlText);
            toolStripStatusLabel.Text = "Downloading... " + (e.BytesReceived / 1024) + "KB / " + (e.TotalBytesToReceive / 1024) + "KB (" + e.ProgressPercentage + "%)";
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void ExtractZip (string archiveFilenameIn, string outFolder, string FileName = null) {
            ZipFile zf = null;
            try {
                FileStream fs = File.OpenRead (archiveFilenameIn);
                zf = new ZipFile (fs);
                foreach (ZipEntry zipEntry in zf) {
                    if (!zipEntry.IsFile || FileName != null && !zipEntry.Name.Equals (FileName))
                        continue;
                    string entryFileName = zipEntry.Name;

                    byte[] buffer = new byte[4096]; //4K is optimum
                    Stream zipStream = zf.GetInputStream (zipEntry);

                    // Manipulate the output filename here as desired
                    string fullZipToPath = Path.Combine (outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName (fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory (directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create (fullZipToPath))
                        StreamUtils.Copy (zipStream, streamWriter, buffer);
                }
            } finally {
                if (zf != null) {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close (); // Ensure we release resources
                }
            }
        }

        private void DownloadFDLauncher () {
            Uri uri = new Uri ("https://github.com//Final-Duel/archive/Launcher.zip");
            string path = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location);
            string zipName = "\\FinalDuelLauncher.zip";

            using (WebClient client = new WebClient ()) {
                client.DownloadFileAsync (uri, path + zipName);
                client.DownloadProgressChanged += client_DownloadProgressChanged;
            }
        }

        private void buttonModBrowseFile_Click (object sender, EventArgs e) {
            if (openFileDialogModFilePath.ShowDialog () == DialogResult.OK)
                textBoxModFile.Text = openFileDialogModFilePath.FileName;
        }

        private void buttonModFilelistAdd_Click (object sender, EventArgs e) {
            string ModFilePath = textBoxModFile.Text;
            if (File.Exists (ModFilePath)) {
                if (listBoxModFilelist.SelectedIndex >= 0)
                    listBoxModFilelist.Items.Insert (listBoxModFilelist.SelectedIndex + 1, ModFilePath);
                else
                    listBoxModFilelist.Items.Add (ModFilePath);
                textBoxModFile.Text = "";
                SaveModList ();
            } else
                MessageBox.Show ("Invalid path", "Invalid file path", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonModFilelistRemove_Click (object sender, EventArgs e) {
            if (listBoxModFilelist.SelectedIndex >= 0) {
                listBoxModFilelist.Items.RemoveAt (listBoxModFilelist.SelectedIndex);
                SaveModList ();
            }
        }

        private void buttonStartGame_Click (object sender, EventArgs e) {
            // Save the config
            Config.Save ();

            Process.Start (Config.DisPath, BuildCommandLine ());
        }

        private string BuildCommandLine () {
            string cmdline = string.Empty; // Define cmdline

            // Add the IWAD
            cmdline += " -iwad \"" + Config.IWADPath + "\\" + Config.IWAD + "\"";

            // Add the files
            cmdline += " -file";
            // Add the files from the modlist
            foreach (string line in Config.ModList)
                cmdline += " \"" + line + "\"";

            // Add Final Duel
            cmdline += " \"" + Config.FDPath + "\"";

            if (!Config.NoSkill) {
                // Skill/Difficulty
                cmdline += " -skill " + Config.Skill;

                // Map Number
                if (!Config.MapNameOn) // If Config.MapNameOn is false
                    cmdline += " -warp " + Config.MapNumber; // Add the map number
                else
                    cmdline += " +map " + Config.MapName; // Add the map name

                // Class
                cmdline += " +playerclass ";
                if (!Config.ClassNumberOn) // If Config.ClassNumberOn is false
                    cmdline += Config.ClassName; // Add the class name
                else
                    cmdline += Config.ClassNumber; // Add the class number
            }

            // Multiplayer
            if (Config.MultiplayerOn) {
                // Hosting/Joining
                if (!Config.MPJoining)
                    cmdline += " -host " + Config.MPPlayers;
                if (Config.MPJoining)
                    cmdline += " -join " + Config.MPHostname;
                cmdline += " -port " + Config.MPPort;
                // Server-side stuff
                if (!Config.MPJoining) {
                    // Server Type
                    if (Config.Netmode == false)
                        cmdline += " -netmode 0";
                    else if (Config.Netmode == true)
                        cmdline += " -netmode 1";

                    // Server Options
                    if (Config.ExtraTics)
                        cmdline += " -extratic";
                    if (Config.MPDup > 0)
                        cmdline += " -dup " + Config.MPDup;

                    // Game mode
                    if (Config.altdeath)
                        cmdline += " -altdeath";
                    if (Config.Deathmatch)
                        cmdline += " -deathmatch";
                }
            }

            // Enable Cheats
            if (Config.sv_cheats)
                cmdline += " +set sv_cheats 1";

            // Enable Logging to File
            if (Config.LogToFile)
                cmdline += " +set logfile \"Final Duel.log\"";

            // Load Savegame
            if (Config.LoadGame != string.Empty)
                cmdline += " -loadgame " + Config.DisPath + "\\" + Config.LoadGame;

            // Custom Commands
            if (Config.CustomCommands != string.Empty)
                cmdline += " " + Config.CustomCommands;

            // Log the command line if we're debugging
            Debug.WriteLine ("BuildCommandLine returned \"" + cmdline + "\"");

            // Return cmdline
            return cmdline;
        }

        private void buttonModFilelistMoveUp_Click (object sender, EventArgs e) {
            int oldSelectedIndex = listBoxModFilelist.SelectedIndex; // define oldSelectedIndex and assign listBoxModFilelist.SelectedIndex to it

            // If the selected index is greater than 0
            if (listBoxModFilelist.SelectedIndex > 0) {
                // Insert a new item to the listbox with the value of the selected item
                listBoxModFilelist.Items.Insert (listBoxModFilelist.SelectedIndex - 1, listBoxModFilelist.SelectedItem);
                listBoxModFilelist.Items.RemoveAt (listBoxModFilelist.SelectedIndex); // Remove the selected item
                listBoxModFilelist.SelectedIndex = oldSelectedIndex - 1; // Select the new item
                // Save the modlist
                SaveModList ();
            }
        }

        private void buttonModFilelistMoveDown_Click (object sender, EventArgs e) {
            int oldSelectedIndex = listBoxModFilelist.SelectedIndex; // Define oldSelectedIndex and assign listBoxModFilelist.SelectedIndex to it

            // If the selected index is less than the highest index AND the selected index is greater than or equal to 0
            if (listBoxModFilelist.SelectedIndex < (listBoxModFilelist.Items.Count - 1) && listBoxModFilelist.SelectedIndex >= 0) {
                // Insert a new item to the listbox with the value of the selected item
                listBoxModFilelist.Items.Insert (listBoxModFilelist.SelectedIndex + 2, listBoxModFilelist.SelectedItem);
                // Remove the selected item
                listBoxModFilelist.Items.RemoveAt (listBoxModFilelist.SelectedIndex);
                // Select the new item
                listBoxModFilelist.SelectedIndex = oldSelectedIndex + 1;
                // Save the modlist
                SaveModList ();
            }
        }

        private void comboBoxIWAD_SelectedValueChanged (object sender, EventArgs e) {
            if ((string)comboBoxIWAD.SelectedItem == "Doom")
                Config.IWAD = "doom.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Doom BFG Edition")
                Config.IWAD = "bfgdoom.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Ultimate Doom")
                Config.IWAD = "doomu.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Doom 2")
                Config.IWAD = "doom2.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Doom 2 BFG Edition")
                Config.IWAD = "bfgdoom2.wad";
            if ((string)comboBoxIWAD.SelectedItem == "TNT")
                Config.IWAD = "tnt.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Plutonia")
                Config.IWAD = "plutonia.wad";
        }

        public void SaveModList () {
            List<string> NewModList = new List<string> ();

            foreach (string line in listBoxModFilelist.Items)
                NewModList.Add (line);
            Config.ModList.RemoveRange (0, Config.ModList.Count);
            Config.ModList.AddRange (NewModList);
        }

        private void checkBoxNoSkill_CheckedChanged (object sender, EventArgs e) {
            if (checkBoxNoSkill.Checked) {
                Config.NoSkill = true;
                numericUpDownSkill.Enabled = false;
            } else {
                Config.NoSkill = false;
                numericUpDownSkill.Enabled = true;
            }
        }

        private void numericUpDownSkill_ValueChanged (object sender, EventArgs e) { Config.Skill = (short)numericUpDownSkill.Value; }

        private void textBoxPK3Path_TextChanged (object sender, EventArgs e) { Config.FDPath = textBoxPK3Path.Text; }

        private void textBoxDisPath_TextChanged (object sender, EventArgs e) { Config.DisPath = textBoxDisPath.Text; }

        private void numericUpDownMap_ValueChanged (object sender, EventArgs e) { Config.MapNumber = (short)numericUpDownMap.Value; }

        private void numericUpDownClass_ValueChanged (object sender, EventArgs e) { Config.ClassNumber = (short)numericUpDownClass.Value; }

        private void textBoxClass_TextChanged (object sender, EventArgs e) { Config.ClassName = textBoxClass.Text; }

        private void textBoxMap_TextChanged (object sender, EventArgs e) { Config.MapName = textBoxMap.Text; }

        private void radioButtonHosting_CheckedChanged (object sender, EventArgs e) {
            if (radioButtonHosting.Checked) {
                textBoxJoinTargetIP.Enabled = false;
                numericUpDownPlayerNum.Enabled = true;
                Config.MPJoining = false;
            } else {
                textBoxJoinTargetIP.Enabled = true;
                numericUpDownPlayerNum.Enabled = false;
                Config.MPJoining = true;
            }
        }

        private void numericUpDownPlayerNum_ValueChanged (object sender, EventArgs e) { Config.MPPlayers = (int)numericUpDownPlayerNum.Value; }

        private void textBoxJoinTargetIP_TextChanged (object sender, EventArgs e) { Config.MPHostname = textBoxJoinTargetIP.Text; }

        private void radioButtonMPP2P_CheckedChanged (object sender, EventArgs e) { Config.Netmode = !radioButtonMPP2P.Checked; }

        private void checkBoxExtraTics_CheckedChanged (object sender, EventArgs e) { Config.ExtraTics = checkBoxExtraTics.Checked; }

        private void numericUpDownMPDup_ValueChanged (object sender, EventArgs e) { Config.MPDup = (int)numericUpDownMPDup.Value; }

        private void checkBoxDeathmatch_CheckedChanged (object sender, EventArgs e) {
            Config.Deathmatch = checkBoxDeathmatch.Checked;
            if (checkBoxDeathmatch.Checked)
                checkBoxAltdeath.Checked = false;
        }

        private void checkBoxAltdeath_CheckedChanged (object sender, EventArgs e) {
            Config.altdeath = checkBoxAltdeath.Checked;
            if (checkBoxAltdeath.Checked)
                checkBoxDeathmatch.Checked = false;
        }
    }
}