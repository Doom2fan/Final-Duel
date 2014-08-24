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

        private void Form1_Load(object sender, EventArgs e)
        {

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
            string IWADsPath = textBoxIWADPath.Text;
            comboBoxIWAD.BeginUpdate();
            comboBoxIWAD.Items.Clear();
            if (File.Exists(IWADsPath+"\\doom.wad"))
                comboBoxIWAD.Items.Add("Doom");
            if (File.Exists(IWADsPath+"\\bfgdoom.wad"))
                comboBoxIWAD.Items.Add("Doom BFG Edition");
            if (File.Exists(IWADsPath+"\\doomu.wad"))
                comboBoxIWAD.Items.Add("Ultimate Doom");
            if (File.Exists(IWADsPath+"\\doom2.wad"))
                comboBoxIWAD.Items.Add("Doom 2");
            if (File.Exists(IWADsPath+"\\bfgdoom2.wad"))
                comboBoxIWAD.Items.Add("Doom 2 BFG Edition");
            if (File.Exists(IWADsPath+"\\tnt.wad"))
                comboBoxIWAD.Items.Add("TNT");
            if (File.Exists(IWADsPath+"\\plutonia.wad"))
                comboBoxIWAD.Items.Add("Plutonia");
            comboBoxIWAD.EndUpdate();
        }

        private void checkBoxMap_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMap.Checked)
            {
                numericUpDownMap.Value = 0;
                numericUpDownMap.Visible = false;
                textBoxMap.Visible = true;
            }
            else
            {
                textBoxMap.Text = "";
                textBoxMap.Visible = false;
                numericUpDownMap.Visible = true;
            }
        }

        private void checkBoxClass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClass.Checked)
            {
                textBoxClass.Text = "";
                textBoxClass.Visible = false;
                numericUpDownClass.Visible = true;
            }
            else
            {
                numericUpDownClass.Value = 0;
                numericUpDownClass.Visible = false;
                textBoxClass.Visible = true;
            }
        }

        private void buttonCheckUpdates_Click(object sender, EventArgs e) // Directory.GetCurrentDirectory()
        {
            toolStripStatusLabel.Text = "Checking for updates...";
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

            }
        }

        private void DownloadFDLauncher()
        {
            Uri uri = new Uri("https://github.com//Final-Duel/archive/Launcher.zip");
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string zipName = "\\FinalDuelLauncher.zip";

            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(uri, path + zipName);
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripStatusLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            toolStripStatusLabel.Text = "Downloading... " + (e.BytesReceived / 1024) + "KB / " + (e.TotalBytesToReceive / 1024) + "KB (" + e.ProgressPercentage + "%)";
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                ExtractDRPG();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void ExtractDRPG()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
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
            }
        }

    }
}
