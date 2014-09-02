﻿namespace Launcher
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialogDisPath = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.basicTab = new System.Windows.Forms.TabPage();
            this.checkBoxClass = new System.Windows.Forms.CheckBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.checkBoxMap = new System.Windows.Forms.CheckBox();
            this.labelMap = new System.Windows.Forms.Label();
            this.numericUpDownSkill = new System.Windows.Forms.NumericUpDown();
            this.labelSkill = new System.Windows.Forms.Label();
            this.buttonIWADPath = new System.Windows.Forms.Button();
            this.textBoxIWADPath = new System.Windows.Forms.TextBox();
            this.labelIWADPath = new System.Windows.Forms.Label();
            this.comboBoxIWAD = new System.Windows.Forms.ComboBox();
            this.labelIWAD = new System.Windows.Forms.Label();
            this.labelFDPath = new System.Windows.Forms.Label();
            this.buttonPK3Path = new System.Windows.Forms.Button();
            this.textBoxPK3Path = new System.Windows.Forms.TextBox();
            this.labelDisPath = new System.Windows.Forms.Label();
            this.buttonDisPath = new System.Windows.Forms.Button();
            this.textBoxDisPath = new System.Windows.Forms.TextBox();
            this.textBoxMap = new System.Windows.Forms.TextBox();
            this.checkBoxNoSkill = new System.Windows.Forms.CheckBox();
            this.numericUpDownMap = new System.Windows.Forms.NumericUpDown();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.numericUpDownClass = new System.Windows.Forms.NumericUpDown();
            this.multiplayerTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonJoining = new System.Windows.Forms.RadioButton();
            this.labelHosting = new System.Windows.Forms.Label();
            this.numericUpDownPlayerNum = new System.Windows.Forms.NumericUpDown();
            this.radioButtonHosting = new System.Windows.Forms.RadioButton();
            this.advancedTab = new System.Windows.Forms.TabPage();
            this.tabPageMods = new System.Windows.Forms.TabPage();
            this.buttonModFilelistMoveDown = new System.Windows.Forms.Button();
            this.buttonModFilelistMoveUp = new System.Windows.Forms.Button();
            this.buttonModFilelistRemove = new System.Windows.Forms.Button();
            this.buttonModFilelistAdd = new System.Windows.Forms.Button();
            this.labelModFile = new System.Windows.Forms.Label();
            this.buttonModBrowseFile = new System.Windows.Forms.Button();
            this.textBoxModFile = new System.Windows.Forms.TextBox();
            this.listBoxModFilelist = new System.Windows.Forms.ListBox();
            this.tabPageUpdates = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonVersionBeta = new System.Windows.Forms.RadioButton();
            this.radioButtonVersionRelease = new System.Windows.Forms.RadioButton();
            this.buttonCheckUpdates = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonUpdateMod = new System.Windows.Forms.RadioButton();
            this.radioButtonUpdateLauncher = new System.Windows.Forms.RadioButton();
            this.openFileDialogPK3Path = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogIWADPath = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogModFilePath = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.textBoxJoinTargetIP = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonMPP2P = new System.Windows.Forms.RadioButton();
            this.radioButtonMPPS = new System.Windows.Forms.RadioButton();
            this.checkBoxExtraTics = new System.Windows.Forms.CheckBox();
            this.checkBoxDeathmatch = new System.Windows.Forms.CheckBox();
            this.numericUpDownMPDup = new System.Windows.Forms.NumericUpDown();
            this.labelDup = new System.Windows.Forms.Label();
            this.checkBoxAltdeath = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.basicTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClass)).BeginInit();
            this.multiplayerTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayerNum)).BeginInit();
            this.tabPageMods.SuspendLayout();
            this.tabPageUpdates.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMPDup)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogDisPath
            // 
            this.openFileDialogDisPath.FileName = "Dis.exe";
            this.openFileDialogDisPath.Filter = "Exe file|*.exe";
            this.openFileDialogDisPath.Title = "Specify Dis path...";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.basicTab);
            this.tabControl1.Controls.Add(this.multiplayerTab);
            this.tabControl1.Controls.Add(this.advancedTab);
            this.tabControl1.Controls.Add(this.tabPageMods);
            this.tabControl1.Controls.Add(this.tabPageUpdates);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 307);
            this.tabControl1.TabIndex = 1;
            // 
            // basicTab
            // 
            this.basicTab.CausesValidation = false;
            this.basicTab.Controls.Add(this.checkBoxClass);
            this.basicTab.Controls.Add(this.labelClass);
            this.basicTab.Controls.Add(this.checkBoxMap);
            this.basicTab.Controls.Add(this.labelMap);
            this.basicTab.Controls.Add(this.numericUpDownSkill);
            this.basicTab.Controls.Add(this.labelSkill);
            this.basicTab.Controls.Add(this.buttonIWADPath);
            this.basicTab.Controls.Add(this.textBoxIWADPath);
            this.basicTab.Controls.Add(this.labelIWADPath);
            this.basicTab.Controls.Add(this.comboBoxIWAD);
            this.basicTab.Controls.Add(this.labelIWAD);
            this.basicTab.Controls.Add(this.labelFDPath);
            this.basicTab.Controls.Add(this.buttonPK3Path);
            this.basicTab.Controls.Add(this.textBoxPK3Path);
            this.basicTab.Controls.Add(this.labelDisPath);
            this.basicTab.Controls.Add(this.buttonDisPath);
            this.basicTab.Controls.Add(this.textBoxDisPath);
            this.basicTab.Controls.Add(this.textBoxMap);
            this.basicTab.Controls.Add(this.checkBoxNoSkill);
            this.basicTab.Controls.Add(this.numericUpDownMap);
            this.basicTab.Controls.Add(this.textBoxClass);
            this.basicTab.Controls.Add(this.numericUpDownClass);
            this.basicTab.Location = new System.Drawing.Point(4, 22);
            this.basicTab.Name = "basicTab";
            this.basicTab.Padding = new System.Windows.Forms.Padding(3);
            this.basicTab.Size = new System.Drawing.Size(552, 281);
            this.basicTab.TabIndex = 0;
            this.basicTab.Text = "Basic";
            this.basicTab.UseVisualStyleBackColor = true;
            // 
            // checkBoxClass
            // 
            this.checkBoxClass.AutoSize = true;
            this.checkBoxClass.Location = new System.Drawing.Point(378, 119);
            this.checkBoxClass.Name = "checkBoxClass";
            this.checkBoxClass.Size = new System.Drawing.Size(63, 17);
            this.checkBoxClass.TabIndex = 18;
            this.checkBoxClass.Text = "Number";
            this.checkBoxClass.UseVisualStyleBackColor = true;
            this.checkBoxClass.CheckedChanged += new System.EventHandler(this.checkBoxClass_CheckedChanged);
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(344, 119);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(32, 13);
            this.labelClass.TabIndex = 17;
            this.labelClass.Text = "Class";
            // 
            // checkBoxMap
            // 
            this.checkBoxMap.AutoSize = true;
            this.checkBoxMap.Location = new System.Drawing.Point(272, 119);
            this.checkBoxMap.Name = "checkBoxMap";
            this.checkBoxMap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxMap.Size = new System.Drawing.Size(76, 17);
            this.checkBoxMap.TabIndex = 15;
            this.checkBoxMap.Text = "Map name";
            this.checkBoxMap.UseVisualStyleBackColor = true;
            this.checkBoxMap.CheckedChanged += new System.EventHandler(this.checkBoxMap_CheckedChanged);
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.Location = new System.Drawing.Point(238, 119);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(28, 13);
            this.labelMap.TabIndex = 13;
            this.labelMap.Text = "Map";
            // 
            // numericUpDownSkill
            // 
            this.numericUpDownSkill.Enabled = false;
            this.numericUpDownSkill.Location = new System.Drawing.Point(138, 136);
            this.numericUpDownSkill.Name = "numericUpDownSkill";
            this.numericUpDownSkill.Size = new System.Drawing.Size(97, 20);
            this.numericUpDownSkill.TabIndex = 12;
            this.numericUpDownSkill.ValueChanged += new System.EventHandler(this.numericUpDownSkill_ValueChanged);
            // 
            // labelSkill
            // 
            this.labelSkill.AutoSize = true;
            this.labelSkill.Location = new System.Drawing.Point(135, 119);
            this.labelSkill.Name = "labelSkill";
            this.labelSkill.Size = new System.Drawing.Size(26, 13);
            this.labelSkill.TabIndex = 11;
            this.labelSkill.Text = "Skill";
            // 
            // buttonIWADPath
            // 
            this.buttonIWADPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIWADPath.Location = new System.Drawing.Point(481, 97);
            this.buttonIWADPath.Name = "buttonIWADPath";
            this.buttonIWADPath.Size = new System.Drawing.Size(51, 20);
            this.buttonIWADPath.TabIndex = 10;
            this.buttonIWADPath.Text = "Browse";
            this.buttonIWADPath.UseVisualStyleBackColor = true;
            this.buttonIWADPath.Click += new System.EventHandler(this.buttonIWADPath_Click);
            // 
            // textBoxIWADPath
            // 
            this.textBoxIWADPath.Location = new System.Drawing.Point(11, 97);
            this.textBoxIWADPath.Name = "textBoxIWADPath";
            this.textBoxIWADPath.Size = new System.Drawing.Size(466, 20);
            this.textBoxIWADPath.TabIndex = 9;
            this.textBoxIWADPath.Tag = "";
            this.textBoxIWADPath.TextChanged += new System.EventHandler(this.textBoxIWADPath_TextChanged);
            // 
            // labelIWADPath
            // 
            this.labelIWADPath.AutoSize = true;
            this.labelIWADPath.Location = new System.Drawing.Point(8, 81);
            this.labelIWADPath.Name = "labelIWADPath";
            this.labelIWADPath.Size = new System.Drawing.Size(81, 13);
            this.labelIWADPath.TabIndex = 8;
            this.labelIWADPath.Text = "IWADs location";
            // 
            // comboBoxIWAD
            // 
            this.comboBoxIWAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIWAD.FormattingEnabled = true;
            this.comboBoxIWAD.Location = new System.Drawing.Point(11, 136);
            this.comboBoxIWAD.Name = "comboBoxIWAD";
            this.comboBoxIWAD.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIWAD.TabIndex = 7;
            this.comboBoxIWAD.SelectedValueChanged += new System.EventHandler(this.comboBoxIWAD_SelectedValueChanged);
            // 
            // labelIWAD
            // 
            this.labelIWAD.AutoSize = true;
            this.labelIWAD.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelIWAD.Location = new System.Drawing.Point(8, 120);
            this.labelIWAD.Name = "labelIWAD";
            this.labelIWAD.Size = new System.Drawing.Size(36, 13);
            this.labelIWAD.TabIndex = 6;
            this.labelIWAD.Text = "IWAD";
            // 
            // labelFDPath
            // 
            this.labelFDPath.AutoSize = true;
            this.labelFDPath.Location = new System.Drawing.Point(8, 42);
            this.labelFDPath.Name = "labelFDPath";
            this.labelFDPath.Size = new System.Drawing.Size(67, 13);
            this.labelFDPath.TabIndex = 5;
            this.labelFDPath.Text = "PK3 location";
            // 
            // buttonPK3Path
            // 
            this.buttonPK3Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPK3Path.Location = new System.Drawing.Point(481, 58);
            this.buttonPK3Path.Name = "buttonPK3Path";
            this.buttonPK3Path.Size = new System.Drawing.Size(51, 20);
            this.buttonPK3Path.TabIndex = 4;
            this.buttonPK3Path.Text = "Browse";
            this.buttonPK3Path.UseVisualStyleBackColor = true;
            this.buttonPK3Path.Click += new System.EventHandler(this.buttonPK3Path_Click);
            // 
            // textBoxPK3Path
            // 
            this.textBoxPK3Path.Location = new System.Drawing.Point(11, 58);
            this.textBoxPK3Path.Name = "textBoxPK3Path";
            this.textBoxPK3Path.Size = new System.Drawing.Size(466, 20);
            this.textBoxPK3Path.TabIndex = 3;
            this.textBoxPK3Path.Tag = "";
            this.textBoxPK3Path.TextChanged += new System.EventHandler(this.textBoxPK3Path_TextChanged);
            // 
            // labelDisPath
            // 
            this.labelDisPath.AutoSize = true;
            this.labelDisPath.Location = new System.Drawing.Point(8, 3);
            this.labelDisPath.Name = "labelDisPath";
            this.labelDisPath.Size = new System.Drawing.Size(62, 13);
            this.labelDisPath.TabIndex = 2;
            this.labelDisPath.Text = "Dis location";
            // 
            // buttonDisPath
            // 
            this.buttonDisPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisPath.Location = new System.Drawing.Point(481, 19);
            this.buttonDisPath.Name = "buttonDisPath";
            this.buttonDisPath.Size = new System.Drawing.Size(51, 20);
            this.buttonDisPath.TabIndex = 1;
            this.buttonDisPath.Text = "Browse";
            this.buttonDisPath.UseVisualStyleBackColor = true;
            this.buttonDisPath.Click += new System.EventHandler(this.buttonDisPath_Click);
            // 
            // textBoxDisPath
            // 
            this.textBoxDisPath.Location = new System.Drawing.Point(11, 19);
            this.textBoxDisPath.Name = "textBoxDisPath";
            this.textBoxDisPath.Size = new System.Drawing.Size(466, 20);
            this.textBoxDisPath.TabIndex = 0;
            this.textBoxDisPath.Tag = "";
            this.textBoxDisPath.TextChanged += new System.EventHandler(this.textBoxDisPath_TextChanged);
            // 
            // textBoxMap
            // 
            this.textBoxMap.Location = new System.Drawing.Point(241, 136);
            this.textBoxMap.Name = "textBoxMap";
            this.textBoxMap.Size = new System.Drawing.Size(100, 20);
            this.textBoxMap.TabIndex = 16;
            this.textBoxMap.Visible = false;
            this.textBoxMap.TextChanged += new System.EventHandler(this.textBoxMap_TextChanged);
            // 
            // checkBoxNoSkill
            // 
            this.checkBoxNoSkill.AutoSize = true;
            this.checkBoxNoSkill.Checked = true;
            this.checkBoxNoSkill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNoSkill.Location = new System.Drawing.Point(167, 119);
            this.checkBoxNoSkill.Name = "checkBoxNoSkill";
            this.checkBoxNoSkill.Size = new System.Drawing.Size(79, 17);
            this.checkBoxNoSkill.TabIndex = 21;
            this.checkBoxNoSkill.Text = "Main Menu";
            this.checkBoxNoSkill.UseVisualStyleBackColor = true;
            this.checkBoxNoSkill.CheckedChanged += new System.EventHandler(this.checkBoxNoSkill_CheckedChanged);
            // 
            // numericUpDownMap
            // 
            this.numericUpDownMap.Location = new System.Drawing.Point(241, 136);
            this.numericUpDownMap.Name = "numericUpDownMap";
            this.numericUpDownMap.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownMap.TabIndex = 14;
            this.numericUpDownMap.ValueChanged += new System.EventHandler(this.numericUpDownMap_ValueChanged);
            // 
            // textBoxClass
            // 
            this.textBoxClass.Location = new System.Drawing.Point(347, 136);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(94, 20);
            this.textBoxClass.TabIndex = 19;
            this.textBoxClass.TextChanged += new System.EventHandler(this.textBoxClass_TextChanged);
            // 
            // numericUpDownClass
            // 
            this.numericUpDownClass.Location = new System.Drawing.Point(347, 136);
            this.numericUpDownClass.Name = "numericUpDownClass";
            this.numericUpDownClass.Size = new System.Drawing.Size(94, 20);
            this.numericUpDownClass.TabIndex = 20;
            this.numericUpDownClass.Visible = false;
            this.numericUpDownClass.ValueChanged += new System.EventHandler(this.numericUpDownClass_ValueChanged);
            // 
            // multiplayerTab
            // 
            this.multiplayerTab.Controls.Add(this.checkBoxAltdeath);
            this.multiplayerTab.Controls.Add(this.labelDup);
            this.multiplayerTab.Controls.Add(this.numericUpDownMPDup);
            this.multiplayerTab.Controls.Add(this.checkBoxDeathmatch);
            this.multiplayerTab.Controls.Add(this.checkBoxExtraTics);
            this.multiplayerTab.Controls.Add(this.groupBox4);
            this.multiplayerTab.Controls.Add(this.groupBox3);
            this.multiplayerTab.Location = new System.Drawing.Point(4, 22);
            this.multiplayerTab.Name = "multiplayerTab";
            this.multiplayerTab.Padding = new System.Windows.Forms.Padding(3);
            this.multiplayerTab.Size = new System.Drawing.Size(552, 281);
            this.multiplayerTab.TabIndex = 1;
            this.multiplayerTab.Text = "Multiplayer";
            this.multiplayerTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonJoining);
            this.groupBox3.Controls.Add(this.labelHosting);
            this.groupBox3.Controls.Add(this.numericUpDownPlayerNum);
            this.groupBox3.Controls.Add(this.radioButtonHosting);
            this.groupBox3.Controls.Add(this.textBoxJoinTargetIP);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 112);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mode";
            // 
            // radioButtonJoining
            // 
            this.radioButtonJoining.AutoSize = true;
            this.radioButtonJoining.Location = new System.Drawing.Point(6, 58);
            this.radioButtonJoining.Name = "radioButtonJoining";
            this.radioButtonJoining.Size = new System.Drawing.Size(58, 17);
            this.radioButtonJoining.TabIndex = 1;
            this.radioButtonJoining.Text = "Joining";
            this.radioButtonJoining.UseVisualStyleBackColor = true;
            // 
            // labelHosting
            // 
            this.labelHosting.AutoSize = true;
            this.labelHosting.Location = new System.Drawing.Point(22, 39);
            this.labelHosting.Name = "labelHosting";
            this.labelHosting.Size = new System.Drawing.Size(41, 13);
            this.labelHosting.TabIndex = 2;
            this.labelHosting.Text = "Players";
            // 
            // numericUpDownPlayerNum
            // 
            this.numericUpDownPlayerNum.Location = new System.Drawing.Point(69, 37);
            this.numericUpDownPlayerNum.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownPlayerNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPlayerNum.Name = "numericUpDownPlayerNum";
            this.numericUpDownPlayerNum.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownPlayerNum.TabIndex = 1;
            this.numericUpDownPlayerNum.Tag = "";
            this.numericUpDownPlayerNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPlayerNum.ValueChanged += new System.EventHandler(this.numericUpDownPlayerNum_ValueChanged);
            // 
            // radioButtonHosting
            // 
            this.radioButtonHosting.AutoSize = true;
            this.radioButtonHosting.Checked = true;
            this.radioButtonHosting.Location = new System.Drawing.Point(6, 19);
            this.radioButtonHosting.Name = "radioButtonHosting";
            this.radioButtonHosting.Size = new System.Drawing.Size(61, 17);
            this.radioButtonHosting.TabIndex = 0;
            this.radioButtonHosting.TabStop = true;
            this.radioButtonHosting.Text = "Hosting";
            this.radioButtonHosting.UseVisualStyleBackColor = true;
            this.radioButtonHosting.CheckedChanged += new System.EventHandler(this.radioButtonHosting_CheckedChanged);
            // 
            // advancedTab
            // 
            this.advancedTab.Location = new System.Drawing.Point(4, 22);
            this.advancedTab.Name = "advancedTab";
            this.advancedTab.Padding = new System.Windows.Forms.Padding(3);
            this.advancedTab.Size = new System.Drawing.Size(552, 281);
            this.advancedTab.TabIndex = 2;
            this.advancedTab.Text = "Advanced";
            this.advancedTab.UseVisualStyleBackColor = true;
            // 
            // tabPageMods
            // 
            this.tabPageMods.Controls.Add(this.buttonModFilelistMoveDown);
            this.tabPageMods.Controls.Add(this.buttonModFilelistMoveUp);
            this.tabPageMods.Controls.Add(this.buttonModFilelistRemove);
            this.tabPageMods.Controls.Add(this.buttonModFilelistAdd);
            this.tabPageMods.Controls.Add(this.labelModFile);
            this.tabPageMods.Controls.Add(this.buttonModBrowseFile);
            this.tabPageMods.Controls.Add(this.textBoxModFile);
            this.tabPageMods.Controls.Add(this.listBoxModFilelist);
            this.tabPageMods.Location = new System.Drawing.Point(4, 22);
            this.tabPageMods.Name = "tabPageMods";
            this.tabPageMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMods.Size = new System.Drawing.Size(552, 281);
            this.tabPageMods.TabIndex = 3;
            this.tabPageMods.Text = "Mods";
            this.tabPageMods.UseVisualStyleBackColor = true;
            // 
            // buttonModFilelistMoveDown
            // 
            this.buttonModFilelistMoveDown.Location = new System.Drawing.Point(466, 123);
            this.buttonModFilelistMoveDown.Name = "buttonModFilelistMoveDown";
            this.buttonModFilelistMoveDown.Size = new System.Drawing.Size(78, 20);
            this.buttonModFilelistMoveDown.TabIndex = 9;
            this.buttonModFilelistMoveDown.Text = "Move down";
            this.buttonModFilelistMoveDown.UseVisualStyleBackColor = true;
            this.buttonModFilelistMoveDown.Click += new System.EventHandler(this.buttonModFilelistMoveDown_Click);
            // 
            // buttonModFilelistMoveUp
            // 
            this.buttonModFilelistMoveUp.Location = new System.Drawing.Point(466, 97);
            this.buttonModFilelistMoveUp.Name = "buttonModFilelistMoveUp";
            this.buttonModFilelistMoveUp.Size = new System.Drawing.Size(78, 20);
            this.buttonModFilelistMoveUp.TabIndex = 8;
            this.buttonModFilelistMoveUp.Text = "Move up";
            this.buttonModFilelistMoveUp.UseVisualStyleBackColor = true;
            this.buttonModFilelistMoveUp.Click += new System.EventHandler(this.buttonModFilelistMoveUp_Click);
            // 
            // buttonModFilelistRemove
            // 
            this.buttonModFilelistRemove.Location = new System.Drawing.Point(466, 71);
            this.buttonModFilelistRemove.Name = "buttonModFilelistRemove";
            this.buttonModFilelistRemove.Size = new System.Drawing.Size(78, 20);
            this.buttonModFilelistRemove.TabIndex = 7;
            this.buttonModFilelistRemove.Text = "Remove";
            this.buttonModFilelistRemove.UseVisualStyleBackColor = true;
            this.buttonModFilelistRemove.Click += new System.EventHandler(this.buttonModFilelistRemove_Click);
            // 
            // buttonModFilelistAdd
            // 
            this.buttonModFilelistAdd.Location = new System.Drawing.Point(466, 45);
            this.buttonModFilelistAdd.Name = "buttonModFilelistAdd";
            this.buttonModFilelistAdd.Size = new System.Drawing.Size(78, 20);
            this.buttonModFilelistAdd.TabIndex = 6;
            this.buttonModFilelistAdd.Text = "Add";
            this.buttonModFilelistAdd.UseVisualStyleBackColor = true;
            this.buttonModFilelistAdd.Click += new System.EventHandler(this.buttonModFilelistAdd_Click);
            // 
            // labelModFile
            // 
            this.labelModFile.AutoSize = true;
            this.labelModFile.Location = new System.Drawing.Point(8, 3);
            this.labelModFile.Name = "labelModFile";
            this.labelModFile.Size = new System.Drawing.Size(63, 13);
            this.labelModFile.TabIndex = 5;
            this.labelModFile.Text = "File location";
            // 
            // buttonModBrowseFile
            // 
            this.buttonModBrowseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModBrowseFile.Location = new System.Drawing.Point(466, 19);
            this.buttonModBrowseFile.Name = "buttonModBrowseFile";
            this.buttonModBrowseFile.Size = new System.Drawing.Size(78, 20);
            this.buttonModBrowseFile.TabIndex = 4;
            this.buttonModBrowseFile.Text = "Browse";
            this.buttonModBrowseFile.UseVisualStyleBackColor = true;
            this.buttonModBrowseFile.Click += new System.EventHandler(this.buttonModBrowseFile_Click);
            // 
            // textBoxModFile
            // 
            this.textBoxModFile.Location = new System.Drawing.Point(11, 19);
            this.textBoxModFile.Name = "textBoxModFile";
            this.textBoxModFile.Size = new System.Drawing.Size(449, 20);
            this.textBoxModFile.TabIndex = 3;
            this.textBoxModFile.Tag = "";
            // 
            // listBoxModFilelist
            // 
            this.listBoxModFilelist.FormattingEnabled = true;
            this.listBoxModFilelist.Location = new System.Drawing.Point(11, 45);
            this.listBoxModFilelist.Name = "listBoxModFilelist";
            this.listBoxModFilelist.Size = new System.Drawing.Size(449, 225);
            this.listBoxModFilelist.TabIndex = 0;
            // 
            // tabPageUpdates
            // 
            this.tabPageUpdates.Controls.Add(this.groupBox2);
            this.tabPageUpdates.Controls.Add(this.buttonCheckUpdates);
            this.tabPageUpdates.Controls.Add(this.groupBox1);
            this.tabPageUpdates.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdates.Name = "tabPageUpdates";
            this.tabPageUpdates.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdates.Size = new System.Drawing.Size(552, 281);
            this.tabPageUpdates.TabIndex = 4;
            this.tabPageUpdates.Text = "Updates";
            this.tabPageUpdates.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonVersionBeta);
            this.groupBox2.Controls.Add(this.radioButtonVersionRelease);
            this.groupBox2.Location = new System.Drawing.Point(109, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 64);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Version";
            // 
            // radioButtonVersionBeta
            // 
            this.radioButtonVersionBeta.AutoSize = true;
            this.radioButtonVersionBeta.Location = new System.Drawing.Point(6, 42);
            this.radioButtonVersionBeta.Name = "radioButtonVersionBeta";
            this.radioButtonVersionBeta.Size = new System.Drawing.Size(47, 17);
            this.radioButtonVersionBeta.TabIndex = 2;
            this.radioButtonVersionBeta.Text = "Beta";
            this.radioButtonVersionBeta.UseVisualStyleBackColor = true;
            // 
            // radioButtonVersionRelease
            // 
            this.radioButtonVersionRelease.AutoSize = true;
            this.radioButtonVersionRelease.Checked = true;
            this.radioButtonVersionRelease.Location = new System.Drawing.Point(6, 19);
            this.radioButtonVersionRelease.Name = "radioButtonVersionRelease";
            this.radioButtonVersionRelease.Size = new System.Drawing.Size(64, 17);
            this.radioButtonVersionRelease.TabIndex = 1;
            this.radioButtonVersionRelease.TabStop = true;
            this.radioButtonVersionRelease.Text = "Release";
            this.radioButtonVersionRelease.UseVisualStyleBackColor = true;
            // 
            // buttonCheckUpdates
            // 
            this.buttonCheckUpdates.AutoSize = true;
            this.buttonCheckUpdates.Location = new System.Drawing.Point(79, 195);
            this.buttonCheckUpdates.Name = "buttonCheckUpdates";
            this.buttonCheckUpdates.Size = new System.Drawing.Size(104, 23);
            this.buttonCheckUpdates.TabIndex = 0;
            this.buttonCheckUpdates.Text = "Check for updates";
            this.buttonCheckUpdates.UseVisualStyleBackColor = true;
            this.buttonCheckUpdates.Click += new System.EventHandler(this.buttonCheckUpdates_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonUpdateMod);
            this.groupBox1.Controls.Add(this.radioButtonUpdateLauncher);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(95, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "What to update";
            // 
            // radioButtonUpdateMod
            // 
            this.radioButtonUpdateMod.AutoSize = true;
            this.radioButtonUpdateMod.Location = new System.Drawing.Point(6, 42);
            this.radioButtonUpdateMod.Name = "radioButtonUpdateMod";
            this.radioButtonUpdateMod.Size = new System.Drawing.Size(46, 17);
            this.radioButtonUpdateMod.TabIndex = 2;
            this.radioButtonUpdateMod.Text = "Mod";
            this.radioButtonUpdateMod.UseVisualStyleBackColor = true;
            // 
            // radioButtonUpdateLauncher
            // 
            this.radioButtonUpdateLauncher.AutoSize = true;
            this.radioButtonUpdateLauncher.Checked = true;
            this.radioButtonUpdateLauncher.Location = new System.Drawing.Point(6, 19);
            this.radioButtonUpdateLauncher.Name = "radioButtonUpdateLauncher";
            this.radioButtonUpdateLauncher.Size = new System.Drawing.Size(70, 17);
            this.radioButtonUpdateLauncher.TabIndex = 1;
            this.radioButtonUpdateLauncher.TabStop = true;
            this.radioButtonUpdateLauncher.Text = "Launcher";
            this.radioButtonUpdateLauncher.UseVisualStyleBackColor = true;
            // 
            // openFileDialogPK3Path
            // 
            this.openFileDialogPK3Path.FileName = "Final_Duel.PK3";
            this.openFileDialogPK3Path.Filter = "PK3 File|*.PK3";
            this.openFileDialogPK3Path.Title = "Specify PK3 path...";
            // 
            // folderBrowserDialogIWADPath
            // 
            this.folderBrowserDialogIWADPath.ShowNewFolderButton = false;
            // 
            // openFileDialogModFilePath
            // 
            this.openFileDialogModFilePath.Filter = "WAD files|*.WAD|PK3 files|*.PK3|PK7 files|*.PK7|All files|*.*";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(560, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(5, 307);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(131, 25);
            this.buttonStartGame.TabIndex = 3;
            this.buttonStartGame.Text = "Launch game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // textBoxJoinTargetIP
            // 
            this.textBoxJoinTargetIP.Enabled = false;
            this.textBoxJoinTargetIP.Location = new System.Drawing.Point(6, 81);
            this.textBoxJoinTargetIP.Name = "textBoxJoinTargetIP";
            this.textBoxJoinTargetIP.Size = new System.Drawing.Size(118, 20);
            this.textBoxJoinTargetIP.TabIndex = 1;
            this.textBoxJoinTargetIP.TabStop = false;
            this.textBoxJoinTargetIP.TextChanged += new System.EventHandler(this.textBoxJoinTargetIP_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonMPPS);
            this.groupBox4.Controls.Add(this.radioButtonMPP2P);
            this.groupBox4.Location = new System.Drawing.Point(148, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(104, 63);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Server Type";
            // 
            // radioButtonMPP2P
            // 
            this.radioButtonMPP2P.AutoSize = true;
            this.radioButtonMPP2P.Checked = true;
            this.radioButtonMPP2P.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMPP2P.Name = "radioButtonMPP2P";
            this.radioButtonMPP2P.Size = new System.Drawing.Size(84, 17);
            this.radioButtonMPP2P.TabIndex = 0;
            this.radioButtonMPP2P.TabStop = true;
            this.radioButtonMPP2P.Text = "Peer-to-Peer";
            this.radioButtonMPP2P.UseVisualStyleBackColor = true;
            this.radioButtonMPP2P.CheckedChanged += new System.EventHandler(this.radioButtonMPP2P_CheckedChanged);
            // 
            // radioButtonMPPS
            // 
            this.radioButtonMPPS.AutoSize = true;
            this.radioButtonMPPS.Location = new System.Drawing.Point(6, 42);
            this.radioButtonMPPS.Name = "radioButtonMPPS";
            this.radioButtonMPPS.Size = new System.Drawing.Size(93, 17);
            this.radioButtonMPPS.TabIndex = 2;
            this.radioButtonMPPS.Text = "Packet Server";
            this.radioButtonMPPS.UseVisualStyleBackColor = true;
            // 
            // checkBoxExtraTics
            // 
            this.checkBoxExtraTics.AutoSize = true;
            this.checkBoxExtraTics.Location = new System.Drawing.Point(154, 75);
            this.checkBoxExtraTics.Name = "checkBoxExtraTics";
            this.checkBoxExtraTics.Size = new System.Drawing.Size(69, 17);
            this.checkBoxExtraTics.TabIndex = 2;
            this.checkBoxExtraTics.Text = "Extra tics";
            this.checkBoxExtraTics.UseVisualStyleBackColor = true;
            this.checkBoxExtraTics.CheckedChanged += new System.EventHandler(this.checkBoxExtraTics_CheckedChanged);
            // 
            // checkBoxDeathmatch
            // 
            this.checkBoxDeathmatch.AutoSize = true;
            this.checkBoxDeathmatch.Location = new System.Drawing.Point(258, 15);
            this.checkBoxDeathmatch.Name = "checkBoxDeathmatch";
            this.checkBoxDeathmatch.Size = new System.Drawing.Size(84, 17);
            this.checkBoxDeathmatch.TabIndex = 3;
            this.checkBoxDeathmatch.Text = "Deathmatch";
            this.checkBoxDeathmatch.UseVisualStyleBackColor = true;
            this.checkBoxDeathmatch.CheckedChanged += new System.EventHandler(this.checkBoxDeathmatch_CheckedChanged);
            // 
            // numericUpDownMPDup
            // 
            this.numericUpDownMPDup.Location = new System.Drawing.Point(184, 92);
            this.numericUpDownMPDup.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownMPDup.Name = "numericUpDownMPDup";
            this.numericUpDownMPDup.Size = new System.Drawing.Size(28, 20);
            this.numericUpDownMPDup.TabIndex = 4;
            this.numericUpDownMPDup.ValueChanged += new System.EventHandler(this.numericUpDownMPDup_ValueChanged);
            // 
            // labelDup
            // 
            this.labelDup.AutoSize = true;
            this.labelDup.Location = new System.Drawing.Point(151, 94);
            this.labelDup.Name = "labelDup";
            this.labelDup.Size = new System.Drawing.Size(27, 13);
            this.labelDup.TabIndex = 5;
            this.labelDup.Text = "Dup";
            // 
            // checkBoxAltdeath
            // 
            this.checkBoxAltdeath.AutoSize = true;
            this.checkBoxAltdeath.Location = new System.Drawing.Point(258, 38);
            this.checkBoxAltdeath.Name = "checkBoxAltdeath";
            this.checkBoxAltdeath.Size = new System.Drawing.Size(99, 17);
            this.checkBoxAltdeath.TabIndex = 6;
            this.checkBoxAltdeath.Text = "Alt Deathmatch";
            this.checkBoxAltdeath.UseVisualStyleBackColor = true;
            this.checkBoxAltdeath.CheckedChanged += new System.EventHandler(this.checkBoxAltdeath_CheckedChanged);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 357);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "formMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Final Duel Launcher";
            this.tabControl1.ResumeLayout(false);
            this.basicTab.ResumeLayout(false);
            this.basicTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClass)).EndInit();
            this.multiplayerTab.ResumeLayout(false);
            this.multiplayerTab.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayerNum)).EndInit();
            this.tabPageMods.ResumeLayout(false);
            this.tabPageMods.PerformLayout();
            this.tabPageUpdates.ResumeLayout(false);
            this.tabPageUpdates.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMPDup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogDisPath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage advancedTab;
        private System.Windows.Forms.TabPage basicTab;
        private System.Windows.Forms.Label labelDisPath;
        private System.Windows.Forms.Button buttonDisPath;
        private System.Windows.Forms.TextBox textBoxDisPath;
        private System.Windows.Forms.TabPage multiplayerTab;
        private System.Windows.Forms.Label labelFDPath;
        private System.Windows.Forms.Button buttonPK3Path;
        private System.Windows.Forms.TextBox textBoxPK3Path;
        private System.Windows.Forms.OpenFileDialog openFileDialogPK3Path;
        private System.Windows.Forms.Label labelIWAD;
        private System.Windows.Forms.ComboBox comboBoxIWAD;
        private System.Windows.Forms.Label labelIWADPath;
        private System.Windows.Forms.Button buttonIWADPath;
        private System.Windows.Forms.TextBox textBoxIWADPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogIWADPath;
        private System.Windows.Forms.NumericUpDown numericUpDownSkill;
        private System.Windows.Forms.Label labelSkill;
        private System.Windows.Forms.NumericUpDown numericUpDownMap;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.CheckBox checkBoxMap;
        private System.Windows.Forms.TextBox textBoxMap;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.CheckBox checkBoxClass;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.TabPage tabPageMods;
        private System.Windows.Forms.NumericUpDown numericUpDownClass;
        private System.Windows.Forms.TabPage tabPageUpdates;
        private System.Windows.Forms.Button buttonCheckUpdates;
        private System.Windows.Forms.RadioButton radioButtonUpdateLauncher;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonUpdateMod;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonVersionBeta;
        private System.Windows.Forms.RadioButton radioButtonVersionRelease;
        private System.Windows.Forms.Label labelModFile;
        private System.Windows.Forms.Button buttonModBrowseFile;
        private System.Windows.Forms.TextBox textBoxModFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogModFilePath;
        private System.Windows.Forms.Button buttonModFilelistAdd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button buttonModFilelistRemove;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.CheckBox checkBoxNoSkill;
        private System.Windows.Forms.Button buttonModFilelistMoveUp;
        private System.Windows.Forms.Button buttonModFilelistMoveDown;
        private System.Windows.Forms.ListBox listBoxModFilelist;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonJoining;
        private System.Windows.Forms.RadioButton radioButtonHosting;
        private System.Windows.Forms.Label labelHosting;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayerNum;
        private System.Windows.Forms.TextBox textBoxJoinTargetIP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonMPP2P;
        private System.Windows.Forms.RadioButton radioButtonMPPS;
        private System.Windows.Forms.CheckBox checkBoxExtraTics;
        private System.Windows.Forms.CheckBox checkBoxDeathmatch;
        private System.Windows.Forms.Label labelDup;
        private System.Windows.Forms.NumericUpDown numericUpDownMPDup;
        private System.Windows.Forms.CheckBox checkBoxAltdeath;
    }
}

