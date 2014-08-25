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
using System.Windows.Forms;

using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace Launcher
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void buttonDisPath_Click(object sender, EventArgs e)
        {
            if (openFileDialogDisPath.ShowDialog() == DialogResult.OK)
                textBoxDisPath.Text = openFileDialogDisPath.FileName;
        }

        private void buttonPK3Path_Click(object sender, EventArgs e)
        {
            if (openFileDialogPK3Path.ShowDialog() == DialogResult.OK)
                textBoxPK3Path.Text = openFileDialogPK3Path.FileName;
        }

        private void buttonIWADPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogIWADPath.ShowDialog() == DialogResult.OK)
                textBoxIWADPath.Text = folderBrowserDialogIWADPath.SelectedPath;
        }

        private void textBoxIWADPath_TextChanged(object sender, EventArgs e)
        {
            Config.IWADPath = textBoxIWADPath.Text;
            comboBoxIWAD.BeginUpdate();
            comboBoxIWAD.Items.Clear();
            if (File.Exists(Config.IWADPath + "\\doom.wad"))
                comboBoxIWAD.Items.Add("Doom");
            if (File.Exists(Config.IWADPath + "\\bfgdoom.wad"))
                comboBoxIWAD.Items.Add("Doom BFG Edition");
            if (File.Exists(Config.IWADPath + "\\doomu.wad"))
                comboBoxIWAD.Items.Add("Ultimate Doom");
            if (File.Exists(Config.IWADPath + "\\doom2.wad"))
                comboBoxIWAD.Items.Add("Doom 2");
            if (File.Exists(Config.IWADPath + "\\bfgdoom2.wad"))
                comboBoxIWAD.Items.Add("Doom 2 BFG Edition");
            if (File.Exists(Config.IWADPath + "\\tnt.wad"))
                comboBoxIWAD.Items.Add("TNT");
            if (File.Exists(Config.IWADPath + "\\plutonia.wad"))
                comboBoxIWAD.Items.Add("Plutonia");
            comboBoxIWAD.EndUpdate();
        }

        private void checkBoxMap_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMap.Checked)
            {
                numericUpDownMap.Visible = false;
                textBoxMap.Visible = true;
                Config.MapNameOn = true;
            }
            else
            {
                textBoxMap.Visible = false;
                numericUpDownMap.Visible = true;
                Config.MapNameOn = false;
            }
        }

        private void checkBoxClass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClass.Checked)
            {
                textBoxClass.Visible = false;
                numericUpDownClass.Visible = true;
                Config.ClassNumberOn = true;
            }
            else
            {
                numericUpDownClass.Visible = false;
                textBoxClass.Visible = true;
                Config.ClassNumberOn = false;
            }
        }

        private void buttonCheckUpdates_Click(object sender, EventArgs e) // Directory.GetCurrentDirectory()
        {
            /*toolStripStatusLabel.Text = "Checking for updates...";
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;

            if (radioButtonVersionRelease.Checked)
            {
                if (radioButtonUpdateLauncher.Checked)
                {
                    
                }
                else
                {

                }
            }
            else
            {

            }*/
        }

        private void DownloadFDLauncher()
        {
            /*Uri uri = new Uri("https://github.com//Final-Duel/archive/Launcher.zip");
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string zipName = "\\FinalDuelLauncher.zip";

            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(uri, path + zipName);
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }*/
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            /*toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            toolStripStatusLabel.Text = "Downloading... " + (e.BytesReceived / 1024) + "KB / " + (e.TotalBytesToReceive / 1024) + "KB (" + e.ProgressPercentage + "%)";
            toolStripProgressBar.Value = e.ProgressPercentage;*/
        }

        private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            /*try
            {
                ExtractDRPG();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }*/
        }

        private void ExtractFD()
        {
            /*string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string zipPath = path + "\\DoomRPG.zip";
            FastZip zip = new FastZip();

            try
            {
                toolStripStatusLabel.Text = "Extracting DoomRPG.zip...";
                toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                Thread extractThread = new Thread(ExtractZip);
                extractThread.Start();
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
            }*/
        }

        private void buttonModBrowseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogModFilePath.ShowDialog() == DialogResult.OK)
                textBoxModFile.Text = openFileDialogModFilePath.FileName;
        }

        private void buttonModFilelistAdd_Click(object sender, EventArgs e)
        {
            string ModFilePath = textBoxModFile.Text;
            if (File.Exists(ModFilePath))
            {
                if (listBoxModFilelist.SelectedIndex >= 0)
                    listBoxModFilelist.Items.Insert(listBoxModFilelist.SelectedIndex + 1, ModFilePath);
                else
                    listBoxModFilelist.Items.Add(ModFilePath);
                textBoxModFile.Text = "";
                SaveModList();
            }
            else
                MessageBox.Show("Invalid path", "Invalid file path", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonModFilelistRemove_Click(object sender, EventArgs e)
        {
            if (listBoxModFilelist.SelectedIndex >= 0)
            {
                listBoxModFilelist.Items.RemoveAt(listBoxModFilelist.SelectedIndex);
                SaveModList();
            }
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Config.Save();
        }

        private string BuildCommandLine()
        {
            string cmdline = string.Empty;

            // IWAD
            cmdline += " -iwad " + textBoxIWADPath + Config.IWAD;

            /*if (config.mapNumber > 0)
            {
                // Skill/Difficulty
                cmdline += " -skill " + ((int)config.difficulty + 1);

                // Map Number
                cmdline += " -warp " + config.mapNumber;

                // DRLA Class
                if (IsDRLAActive())
                    cmdline += " +playerclass " + config.rlClass.ToString();
            }

            // Multiplayer
            if (config.multiplayer)
            {
                // Hosting/Joining
                if (config.multiplayerMode == MultiplayerMode.Hosting)
                    cmdline += " -host " + config.players;
                if (config.multiplayerMode == MultiplayerMode.Joining)
                    cmdline += " -join " + config.hostname;

                // Server-side stuff
                if (config.multiplayerMode == MultiplayerMode.Hosting)
                {
                    // Server Type
                    if (config.serverType == ServerType.PeerToPeer)
                        cmdline += " -netmode 0";
                    if (config.serverType == ServerType.PacketServer)
                        cmdline += " -netmode 1";

                    // Server Options
                    if (config.extraTics)
                        cmdline += " -extratic";
                    if (config.duplicate > 0)
                        cmdline += " -dup " + config.duplicate;
                }
            }

            // Enable Cheats
            if (checkBoxEnableCheats.Checked)
                cmdline += " +sv_cheats 1";

            // Enable Logging to File
            if (checkBoxLogging.Checked)
                cmdline += " +logfile \"Doom RPG.log\"";

            // Load Savegame
            if (comboBoxSaveGame.Text != "None")
                cmdline += " -loadgame " + Path.GetDirectoryName(textBoxPortPath.Text) + "\\" + comboBoxSaveGame.Text;

            // Record Demo
            if (textBoxDemo.TextLength > 0)
                cmdline += " -record " + textBoxDemo.Text + ".lmp";

            // Mods & Patches
            cmdline += " -file";

            // Mods selected from the mods list
            for (int i = 0; i < checkedListBoxMods.Items.Count; i++)
                if (checkedListBoxMods.GetItemChecked(i))
                    cmdline += " \"" + config.modsPath + "\\" + checkedListBoxMods.Items[i].ToString() + "\"";

            // Doom RPG
            cmdline += " \"" + config.DRPGPath + "\\DoomRPG\"";

            // Custom Commands
            if (config.customCommands != string.Empty)
                cmdline += " " + config.customCommands;*/

            return cmdline;
        }

        private void buttonModFilelistMoveUp_Click(object sender, EventArgs e)
        {
            int oldSelectedIndex = listBoxModFilelist.SelectedIndex;
            if (listBoxModFilelist.SelectedIndex > 0)
            {
                listBoxModFilelist.Items.Insert(listBoxModFilelist.SelectedIndex - 1, listBoxModFilelist.SelectedItem);
                listBoxModFilelist.Items.RemoveAt(listBoxModFilelist.SelectedIndex);
                listBoxModFilelist.SelectedIndex = oldSelectedIndex - 1;
                SaveModList();
            }
        }

        private void buttonModFilelistMoveDown_Click(object sender, EventArgs e)
        {
            int oldSelectedIndex = listBoxModFilelist.SelectedIndex;
            if (listBoxModFilelist.SelectedIndex < (listBoxModFilelist.Items.Count - 1) && listBoxModFilelist.SelectedIndex >= 0)
            {
                listBoxModFilelist.Items.Insert(listBoxModFilelist.SelectedIndex + 2, listBoxModFilelist.SelectedItem);
                listBoxModFilelist.Items.RemoveAt(listBoxModFilelist.SelectedIndex);
                listBoxModFilelist.SelectedIndex = oldSelectedIndex + 1;
                SaveModList();
            }
        }

        private void comboBoxIWAD_SelectedValueChanged(object sender, EventArgs e)
        {
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

        public void SaveModList()
        {
            List<string> NewModList = new List<string>();

            for (int i = 0; i < listBoxModFilelist.Items.Count; i++)
            {
                NewModList.Add(listBoxModFilelist.Items[i].ToString());
            }
            Config.ModList.RemoveRange(0, listBoxModFilelist.Items.Count - 1);
            Config.ModList.AddRange(NewModList);
        }

        private void checkBoxNoSkill_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoSkill.Checked)
            {
                Config.NoSkill = true;
                numericUpDownSkill.Enabled = false;
            }
            else
            {
                Config.NoSkill = false;
                numericUpDownSkill.Enabled = true;
            }
        }

        private void numericUpDownSkill_ValueChanged(object sender, EventArgs e) { Config.Skill = (int)numericUpDownSkill.Value; }

        private void textBoxPK3Path_TextChanged(object sender, EventArgs e) { Config.FDPath = textBoxPK3Path.Text; }

        private void textBoxDisPath_TextChanged(object sender, EventArgs e) { Config.DisPath = textBoxDisPath.Text; }

        private void numericUpDownMap_ValueChanged(object sender, EventArgs e) { Config.MapNumber = (int)numericUpDownMap.Value; }

        private void numericUpDownClass_ValueChanged(object sender, EventArgs e) { Config.ClassNumber = (int)numericUpDownClass.Value; }

        private void textBoxClass_TextChanged(object sender, EventArgs e) { Config.ClassName = textBoxClass.Text; }

        private void textBoxMap_TextChanged(object sender, EventArgs e) { Config.MapName = textBoxMap.Text; }

        private void numericUpDownPlayerNum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonJoining_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
