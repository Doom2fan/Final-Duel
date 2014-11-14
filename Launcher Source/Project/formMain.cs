using System;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace Launcher {
    public partial class formMain : Form {
        public formMain () {
            InitializeComponent ();

            Game.Configurations.Initialize ();
            Game.Configurations.Load (Game.Configurations.ConfigName);

            PopulateFields ();
        }

        #region ============ Functions ============

        // Populate the form's fields
        private void PopulateFields () {
            // Paths
            // Dis path
            textBoxDisPath.Text = Game.Configurations.DisPath;

            // IWAD path
            textBoxIWADPath.Text = Game.Configurations.IWADPath;
            comboBoxIWAD.BeginUpdate ();
            comboBoxIWAD.Items.Clear ();
			if (File.Exists (Game.Configurations.IWADPath + "\\doom2.wad") || File.Exists (Game.Configurations.IWADPath + "\\bfgdoom2.wad") || File.Exists (Game.Configurations.IWADPath + "\\tnt.wad") || File.Exists (Game.Configurations.IWADPath + "\\plutonia.wad")) {
				if (File.Exists (Game.Configurations.IWADPath + "\\doom.wad"))
					comboBoxIWAD.Items.Add ("Doom");
				if (File.Exists (Game.Configurations.IWADPath + "\\bfgdoom.wad"))
					comboBoxIWAD.Items.Add ("Doom BFG Edition");
				if (File.Exists (Game.Configurations.IWADPath + "\\doomu.wad"))
					comboBoxIWAD.Items.Add ("Ultimate Doom");
			}
            if (File.Exists (Game.Configurations.IWADPath + "\\doom2.wad"))
                comboBoxIWAD.Items.Add ("Doom 2");
            if (File.Exists (Game.Configurations.IWADPath + "\\bfgdoom2.wad"))
                comboBoxIWAD.Items.Add ("Doom 2 BFG Edition");
            if (File.Exists (Game.Configurations.IWADPath + "\\tnt.wad"))
                comboBoxIWAD.Items.Add ("TNT");
            if (File.Exists (Game.Configurations.IWADPath + "\\plutonia.wad"))
                comboBoxIWAD.Items.Add ("Plutonia");
            comboBoxIWAD.EndUpdate ();

            // PK3 path
            textBoxPK3Path.Text = Game.Configurations.FDPath;

            // Basic
            // Selected IWAD
            numericUpDownMap.Value = Game.Configurations.MapNumber;
            if (Game.Configurations.IWAD.Equals ("doom.wad"))
                comboBoxIWAD.SelectedItem = "Doom";
            if (Game.Configurations.IWAD == "bfgdoom.wad")
                comboBoxIWAD.SelectedItem = "Doom BFG Edition";
            if (Game.Configurations.IWAD == "doomu.wad")
                comboBoxIWAD.SelectedItem = "Ultimate Doom";
            if (Game.Configurations.IWAD == "doom2.wad")
                comboBoxIWAD.SelectedItem = "Doom 2";
            if (Game.Configurations.IWAD == "bfgdoom2.wad")
                comboBoxIWAD.SelectedItem = "Doom 2 BFG Edition";
            if (Game.Configurations.IWAD == "tnt.wad")
                comboBoxIWAD.SelectedItem = "TNT";
            if (Game.Configurations.IWAD == "plutonia.wad")
                comboBoxIWAD.SelectedItem = "Plutonia";

            // Main menu checkbox
            checkBoxNoSkill.Checked = Game.Configurations.NoSkill;

            // Skill/Difficulty
            numericUpDownSkill.Value = Game.Configurations.Skill;

            // Map name checkbox
            checkBoxMap.Checked = Game.Configurations.MapNameOn;

            // Map number
            numericUpDownMap.Value = Game.Configurations.MapNumber;

            // Map name
            textBoxMap.Text = Game.Configurations.MapName;

            // Class number checkbox
            checkBoxClass.Checked = Game.Configurations.ClassNumberOn;

            // Class name
            textBoxClass.Text = Game.Configurations.ClassName;

            // Class number
            numericUpDownClass.Value = Game.Configurations.ClassNumber;


            // Multiplayer
            // Multiplayer on checkbox
            checkBoxMultiplayerOn.Checked = Game.Configurations.MultiplayerOn;

            // Port number
            numericUpDownPort.Value = Game.Configurations.MPPort;

            // Joining
            radioButtonJoining.Checked = Game.Configurations.MPJoining;

            // Hostname
            textBoxJoinTargetIP.Text = Game.Configurations.MPHostname;

            // Players number
            numericUpDownPlayerNum.Value = Game.Configurations.MPPlayers;

            // Netmode
            radioButtonMPP2P.Checked = !Game.Configurations.Netmode;

            // Extra tics checkbox
            checkBoxExtraTics.Checked = Game.Configurations.ExtraTics;

            // Dup number
            numericUpDownMPDup.Value = Game.Configurations.MPDup;

            // Altdeath checkbox
            checkBoxAltdeath.Checked = Game.Configurations.altdeath;

            // Deathmatch checkbox
            checkBoxDeathmatch.Checked = Game.Configurations.Deathmatch;


            // Mods
            listBoxModFilelist.BeginUpdate ();
            foreach (string line in Game.Configurations.ModList)
                listBoxModFilelist.Items.Add (line);
            listBoxModFilelist.EndUpdate ();

            // Advanced
            // sv_cheats checkbox
            checkBoxCheatsOn.Checked = Game.Configurations.sv_cheats;

            // Log to file checkbox
            checkBoxLogToFile.Checked = Game.Configurations.LogToFile;

            // Custom commands textbox
            textBoxCustomCommands.Text = Game.Configurations.CustomCommands;
        }

        // Build the command line
        private string BuildCommandLine () {
            StringBuilder cmdline = new StringBuilder (); // Define cmdline

            // Add the IWAD
			if (!Game.Configurations.IWAD.Equals ("doom.wad") && !Game.Configurations.IWAD.Equals ("udoom.wad") && !Game.Configurations.IWAD.Equals ("bfgdoom.wad"))
				cmdline.Append (" -iwad \"" + Game.Configurations.IWADPath + "\\" + Game.Configurations.IWAD + "\"");
			else {
				string IWAD = null;

				if (File.Exists (Game.Configurations.IWADPath + "\\doom2.wad"))
					IWAD = "\\doom2.wad";
				else if (File.Exists (Game.Configurations.IWADPath + "\\bfgdoom2.wad"))
					IWAD = "\\bfgdoom2.wad";
				else if (File.Exists (Game.Configurations.IWADPath + "\\tnt.wad"))
					IWAD = "\\tnt.wad";
				else if (File.Exists (Game.Configurations.IWADPath + "\\plutonia.wad"))
					IWAD = "\\plutonia.wad";

				if (!string.IsNullOrEmpty (IWAD))
					cmdline.Append ("-iwad \"" + Game.Configurations.IWADPath + IWAD);
			}

            // Add the files
            cmdline.Append (" -file");

			// Add the IWAD if we're using Doom 1 or Ultimate Doom
			if (Game.Configurations.IWAD.Equals ("doom.wad") || Game.Configurations.IWAD.Equals ("udoom.wad") || Game.Configurations.IWAD.Equals ("bfgdoom.wad"))
				cmdline.Append (" \"" + Game.Configurations.IWADPath + Game.Configurations.IWAD + "\"");

            // Add the files from the modlist
            foreach (string line in Game.Configurations.ModList)
                cmdline.Append (" \"" + line + "\"");

            // Add Final Duel
            cmdline.Append (" \"" + Game.Configurations.FDPath + "\"");

            if (!Game.Configurations.NoSkill) {
                // Skill/Difficulty
                cmdline.Append (" -skill " + Game.Configurations.Skill);

                // Map Number
                if (!Game.Configurations.MapNameOn) // If Game.Configurations.MapNameOn is false
                    cmdline.Append (" -warp " + Game.Configurations.MapNumber); // Add the map number
                else
					cmdline.Append (" +map " + Game.Configurations.MapName); // Add the map name

                // Class
                cmdline.Append (" +playerclass ");
                if (!Game.Configurations.ClassNumberOn) // If Game.Configurations.ClassNumberOn is false
                    cmdline.Append (Game.Configurations.ClassName); // Add the class name
                else
                    cmdline.Append (Game.Configurations.ClassNumber); // Add the class number
            }

            // Multiplayer
            if (Game.Configurations.MultiplayerOn) {
                // Hosting/Joining
                if (!Game.Configurations.MPJoining)
                    cmdline.Append (" -host " + Game.Configurations.MPPlayers);
                if (Game.Configurations.MPJoining)
                    cmdline.Append (" -join " + Game.Configurations.MPHostname);
                cmdline.Append (" -port " + Game.Configurations.MPPort);

                // Server-side stuff
                if (!Game.Configurations.MPJoining) {
                    // Server Type
                    if (Game.Configurations.Netmode == false)
                        cmdline.Append (" -netmode 0");
                    else if (Game.Configurations.Netmode == true)
                        cmdline.Append (" -netmode 1");

                    // Server Options
                    if (Game.Configurations.ExtraTics)
                        cmdline.Append (" -extratic");
                    if (Game.Configurations.MPDup > 0)
                        cmdline.Append (" -dup " + Game.Configurations.MPDup);

                    // Game mode
                    if (Game.Configurations.altdeath)
                        cmdline.Append (" -altdeath");
                    if (Game.Configurations.Deathmatch)
                        cmdline.Append (" -deathmatch");
                }
            }

            // Enable Cheats
            if (Game.Configurations.sv_cheats)
                cmdline.Append (" +set sv_cheats 1");

            // Enable Logging to File
            if (Game.Configurations.LogToFile)
                cmdline.Append (" +set logfile \"Final Duel.log\"");

            // Custom Commands
            if (Game.Configurations.CustomCommands != string.Empty)
                cmdline.Append (" " + Game.Configurations.CustomCommands);

            // Log the command line if we're debugging
            Debug.WriteLine ("BuildCommandLine returned \"" + cmdline.ToString () + "\"");

            // Return cmdline
            return cmdline.ToString ();
        }

        // Save the modlist
        public void SaveModList () {
            List<string> NewModList = new List<string> ();

            foreach (string line in listBoxModFilelist.Items)
                NewModList.Add (line);
            Game.Configurations.ModList.RemoveRange (0, Game.Configurations.ModList.Count);
            Game.Configurations.ModList.AddRange (NewModList);
        }

        #endregion

        #region ============ Form code ============

        #region ============ Path settings ============

        // Dis path textbox - Text changed
        private void textBoxDisPath_TextChanged (object sender, EventArgs e) {
            Game.Configurations.DisPath = textBoxDisPath.Text;
        }

        // Browse Dis path button - Clicked
        private void buttonDisPath_Click (object sender, EventArgs e) {
            if (openFileDialogDisPath.ShowDialog () == DialogResult.OK)
                textBoxDisPath.Text = openFileDialogDisPath.FileName;
        }

        // PK3 path testbox - Text changed
        private void textBoxPK3Path_TextChanged (object sender, EventArgs e) {
            Game.Configurations.FDPath = textBoxPK3Path.Text;
        }

        // Browse PK3 path button - Clicked
        private void buttonPK3Path_Click (object sender, EventArgs e) {
            if (openFileDialogPK3Path.ShowDialog () == DialogResult.OK)
                textBoxPK3Path.Text = openFileDialogPK3Path.FileName;
        }

        // Browse IWAD path button - Clicked
        private void buttonIWADPath_Click (object sender, EventArgs e) {
            if (folderBrowserDialogIWADPath.ShowDialog () == DialogResult.OK)
                textBoxIWADPath.Text = folderBrowserDialogIWADPath.SelectedPath;
        }

        // IWAD path textbox - Text changed
        private void textBoxIWADPath_TextChanged (object sender, EventArgs e) {
            Game.Configurations.IWADPath = textBoxIWADPath.Text;
            comboBoxIWAD.BeginUpdate ();
            comboBoxIWAD.Items.Clear ();
            if (File.Exists (Game.Configurations.IWADPath + "\\doom.wad"))
                comboBoxIWAD.Items.Add ("Doom");
            if (File.Exists (Game.Configurations.IWADPath + "\\bfgdoom.wad"))
                comboBoxIWAD.Items.Add ("Doom BFG Edition");
            if (File.Exists (Game.Configurations.IWADPath + "\\doomu.wad"))
                comboBoxIWAD.Items.Add ("Ultimate Doom");
            if (File.Exists (Game.Configurations.IWADPath + "\\doom2.wad"))
                comboBoxIWAD.Items.Add ("Doom 2");
            if (File.Exists (Game.Configurations.IWADPath + "\\bfgdoom2.wad"))
                comboBoxIWAD.Items.Add ("Doom 2 BFG Edition");
            if (File.Exists (Game.Configurations.IWADPath + "\\tnt.wad"))
                comboBoxIWAD.Items.Add ("TNT");
            if (File.Exists (Game.Configurations.IWADPath + "\\plutonia.wad"))
                comboBoxIWAD.Items.Add ("Plutonia");
            comboBoxIWAD.EndUpdate ();
        }

        #endregion

        #region ============ Basic settings ============

        // IWAD combo box - Selected value changed
        private void comboBoxIWAD_SelectedValueChanged (object sender, EventArgs e) {
            if ((string)comboBoxIWAD.SelectedItem == "Doom")
                Game.Configurations.IWAD = "doom.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Doom BFG Edition")
                Game.Configurations.IWAD = "bfgdoom.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Ultimate Doom")
                Game.Configurations.IWAD = "doomu.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Doom 2")
                Game.Configurations.IWAD = "doom2.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Doom 2 BFG Edition")
                Game.Configurations.IWAD = "bfgdoom2.wad";
            if ((string)comboBoxIWAD.SelectedItem == "TNT")
                Game.Configurations.IWAD = "tnt.wad";
            if ((string)comboBoxIWAD.SelectedItem == "Plutonia")
                Game.Configurations.IWAD = "plutonia.wad";
        }

        // Main menu checkbox - Checked changed
        private void checkBoxNoSkill_CheckedChanged (object sender, EventArgs e) {
            if (checkBoxNoSkill.Checked) {
                Game.Configurations.NoSkill = true;
                numericUpDownSkill.Enabled = false;
            } else {
                Game.Configurations.NoSkill = false;
                numericUpDownSkill.Enabled = true;
            }
        }

        // Skill numeric up down - Value changed
        private void numericUpDownSkill_ValueChanged (object sender, EventArgs e) {
            Game.Configurations.Skill = (short)numericUpDownSkill.Value;
        }

        // Map name checkbox - Checked changed
        private void checkBoxMap_CheckedChanged (object sender, EventArgs e) {
            if (checkBoxMap.Checked) {
                numericUpDownMap.Visible = false;
                textBoxMap.Visible = true;
                Game.Configurations.MapNameOn = true;
            } else {
                textBoxMap.Visible = false;
                numericUpDownMap.Visible = true;
                Game.Configurations.MapNameOn = false;
            }
        }

        // Map numeric up down - Value changed
        private void numericUpDownMap_ValueChanged (object sender, EventArgs e) {
            Game.Configurations.MapNumber = (short)numericUpDownMap.Value;
        }

        // Map textbox - Text changed
        private void textBoxMap_TextChanged (object sender, EventArgs e) {
            Game.Configurations.MapName = textBoxMap.Text;
        }

        // Class number checkbox - Checked changed
        private void checkBoxClass_CheckedChanged (object sender, EventArgs e) {
            if (checkBoxClass.Checked) {
                textBoxClass.Visible = false;
                numericUpDownClass.Visible = true;
                Game.Configurations.ClassNumberOn = true;
            } else {
                numericUpDownClass.Visible = false;
                textBoxClass.Visible = true;
                Game.Configurations.ClassNumberOn = false;
            }
        }

        // Class numeric up down - Value changed
        private void numericUpDownClass_ValueChanged (object sender, EventArgs e) {
            Game.Configurations.ClassNumber = (short)numericUpDownClass.Value;
        }

        // Class textbox - Text changed
        private void textBoxClass_TextChanged (object sender, EventArgs e) {
            Game.Configurations.ClassName = textBoxClass.Text;
        }

        #endregion

        #region ============ Modlist ============

        // Browse button - Clicked
        private void buttonModBrowseFile_Click (object sender, EventArgs e) {
            if (openFileDialogModFilePath.ShowDialog () == DialogResult.OK)
                textBoxModFile.Text = openFileDialogModFilePath.FileName;
        }

        // Add button - Clicked
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

        // Remove button - Clicked
        private void buttonModFilelistRemove_Click (object sender, EventArgs e) {
            if (listBoxModFilelist.SelectedIndex >= 0) {
                listBoxModFilelist.Items.RemoveAt (listBoxModFilelist.SelectedIndex);
                SaveModList ();
            }
        }

        // Move up button - Clicked
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

        // Move down button - Clicked
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

        #endregion

        #region ============ Updater ============

        // Check updates button - Clicked
        private void buttonCheckUpdates_Click (object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Checking for updates...";
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;

            if (radioButtonVersionRelease.Checked) {
                if (radioButtonUpdateLauncher.Checked) {
                } else {
                    if (!File.Exists (Game.Configurations.FDPath)) {
                        toolStripStatusLabel.Text = "Ready";
                        toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                        if (Game.Configurations.FDPath == string.Empty)
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

        // Client - Download progress changed
		private void client_DownloadProgressChanged (object sender, DownloadProgressChangedEventArgs e) {
			toolStripStatusLabel.ForeColor = Color.FromKnownColor (KnownColor.ControlText);
			toolStripStatusLabel.Text = "Downloading... " + (e.BytesReceived / 1024) + "KB / " + (e.TotalBytesToReceive / 1024) + "KB (" + e.ProgressPercentage + "%)";
			toolStripProgressBar.Value = e.ProgressPercentage;
		}

        #region ============ Final Duel ============

        private void UpdaterGetNewestFDRelease_DownloadFileCompleted (object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            string tempPath = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location) + "\\Temp\\ModUpdate";
            //string zipName = "\\Final_Duel_Stable.zip";
            string md5Hash = string.Empty;

            Directory.CreateDirectory (tempPath);
            using (var md5 = MD5.Create ()) {
                using (var stream = File.OpenRead (Game.Configurations.FDPath)) {
                    byte[] Hash = md5.ComputeHash (stream);
                    for (int i = 0; i < (Hash.Count () - 1); i++)
                        md5Hash += Hash.ElementAt (i);
                }
            }

            string[] UploadedVersion = File.ReadAllLines (tempPath + "\\UploadedVersion.txt");
            Utils.Zip.ExtractZip (Game.Configurations.FDPath, tempPath, "FDVERSION.txt");
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

        // Download release
        private void DownloadFDRelease () {

        }

        #endregion

        #region ============ Launcher ============

        // Download Launcher
        private void DownloadLauncherRelease () {
            Uri uri = new Uri ("https://github.com//Final-Duel/archive/Launcher.zip");
            string path = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location);
            string zipName = "\\FinalDuelLauncher.zip";

            using (WebClient client = new WebClient ()) {
                client.DownloadFileAsync (uri, path + zipName);
                client.DownloadProgressChanged += client_DownloadProgressChanged;
            }
        }

        #endregion

        #endregion

        #region ============ Multiplayer ============

        // Multiplayer on checkbox - Checked changed
        private void checkBoxMultiplayerOn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.MultiplayerOn = checkBoxMultiplayerOn.Checked;
        }

        // Hosting radio button - Checked changed
        private void radioButtonHosting_CheckedChanged (object sender, EventArgs e) {
            if (radioButtonHosting.Checked) {
                textBoxJoinTargetIP.Enabled = false;
                numericUpDownPlayerNum.Enabled = true;
                numericUpDownMPDup.Enabled = true;
                numericUpDownPort.Enabled = true;
                checkBoxExtraTics.Enabled = true;
                groupBoxServerType.Enabled = false;
                Game.Configurations.MPJoining = false;
            } else {
                textBoxJoinTargetIP.Enabled = true;
                numericUpDownPlayerNum.Enabled = false;
                Game.Configurations.MPJoining = true;
            }
        }

        // Player number numeric up down - Value changed
        private void numericUpDownPlayerNum_ValueChanged (object sender, EventArgs e) {
            Game.Configurations.MPPlayers = (short)numericUpDownPlayerNum.Value;
        }

        // Hostname textbox - Text changed
        private void textBoxJoinTargetIP_TextChanged (object sender, EventArgs e) {
            Game.Configurations.MPHostname = textBoxJoinTargetIP.Text;
        }

        // Extra tics checkbox - Checked changed
        private void checkBoxExtraTics_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.ExtraTics = checkBoxExtraTics.Checked;
        }

        // Dup numeric up down - Value changed
        private void numericUpDownMPDup_ValueChanged (object sender, EventArgs e) {
            Game.Configurations.MPDup = (short)numericUpDownMPDup.Value;
        }

        // Deathmatch checkbox - Checked changed
        private void checkBoxDeathmatch_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.Deathmatch = checkBoxDeathmatch.Checked;
            if (checkBoxDeathmatch.Checked)
                checkBoxAltdeath.Checked = false;
        }

        // Altdeath checkbox - Checked changed
        private void checkBoxAltdeath_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.altdeath = checkBoxAltdeath.Checked;
            if (checkBoxAltdeath.Checked)
                checkBoxDeathmatch.Checked = false;
        }

        // Peer-to-Peer radio button - Checked changed
        private void radioButtonMPP2P_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.Netmode = !radioButtonMPP2P.Checked;
        }

        #endregion

        #region ============ Advanced ============

        // sv_cheats checkbox - Checked changed
        private void checkBoxCheatsOn_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.sv_cheats = checkBoxCheatsOn.Checked;
        }

        // Log to file checkbox - Checked changed
        private void checkBoxLogToFile_CheckedChanged (object sender, EventArgs e) {
            Game.Configurations.LogToFile = checkBoxLogToFile.Checked;
        }

        // Gameplay options button - Clicked
        private void buttonGameplayOptionsMenu_Click (object sender, EventArgs e) {
            FormGameplayOptions FGameplayOptions = new FormGameplayOptions ();
            FGameplayOptions.ShowDialog ();
        }

        // Custom commands testbox - Text changed
        private void textBoxCustomCommands_TextChanged (object sender, EventArgs e) {
            Game.Configurations.CustomCommands = textBoxCustomCommands.Text;
        }

        #endregion

        // Start game button - Clicked
        private void buttonStartGame_Click (object sender, EventArgs e) {
			try {
				Game.Configurations.Save ("Default"); // Save the configurations
				buttonStartGame.Enabled = false; // Disable the start game button
				ProcessStartInfo DisStartInfo = new ProcessStartInfo ();
				DisStartInfo.FileName = Game.Configurations.DisPath; // Set the file path
				DisStartInfo.Arguments = BuildCommandLine ();
				Process Dis = Process.Start (DisStartInfo); // Start the game;
				Game.Running = true; // Set Game.Running to true
				Game.ProcessID = Dis.Id; // Set Game.ProcessID to the game process' ID
				Task StartGame = new Task (delegate {
					while (!Dis.HasExited) {
						Thread.Sleep (150);
					}
					Game.Running = false;
					EnableStartGameButton ();
				});

				StartGame.Start ();
			} catch (Exception exception) {
				Utils.ShowError (exception);
			}
        }

        delegate void EnableStartGameButtonCallback ();
        private void EnableStartGameButton () {
            if (buttonStartGame.InvokeRequired) {
                EnableStartGameButtonCallback d = new EnableStartGameButtonCallback (EnableStartGameButton);
                this.Invoke (d);
            } else
                buttonStartGame.Enabled = true;
        }

        // Save configuration button - Clicked
        private void buttonSaveConfiguration_Click (object sender, EventArgs e) {
            Game.Configurations.Save (Game.Configurations.ConfigName); // Save the configuration
        }

        // Configuration combo box - Text changed.
        private void comboBoxConfiguration_TextChanged (object sender, EventArgs e) {
            Game.Configurations.ConfigName = comboBoxConfiguration.Text;
        }

        #endregion
    }
}