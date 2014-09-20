namespace Auto_Indentation_Tool {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container ();
            this.listBoxFiles = new System.Windows.Forms.ListBox ();
            this.contextMenuStripFilesList = new System.Windows.Forms.ContextMenuStrip (this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            this.buttonParse = new System.Windows.Forms.Button ();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog ();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog ();
            this.contextMenuStripFilesList.SuspendLayout ();
            this.SuspendLayout ();
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFiles.ContextMenuStrip = this.contextMenuStripFilesList;
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point (0, 0);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size (334, 264);
            this.listBoxFiles.TabIndex = 0;
            this.listBoxFiles.KeyDown += new System.Windows.Forms.KeyEventHandler (this.listBoxFiles_KeyDown);
            // 
            // contextMenuStripFilesList
            // 
            this.contextMenuStripFilesList.Items.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripFilesList.Name = "contextMenuStripFilesList";
            this.contextMenuStripFilesList.Size = new System.Drawing.Size (118, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.folderToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size (117, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size (107, 22);
            this.filesToolStripMenuItem.Text = "Files";
            this.filesToolStripMenuItem.Click += new System.EventHandler (this.filesToolStripMenuItem_Click);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size (107, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler (this.folderToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size (117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // buttonParse
            // 
            this.buttonParse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonParse.Location = new System.Drawing.Point (12, 276);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size (310, 23);
            this.buttonParse.TabIndex = 2;
            this.buttonParse.Text = "Parse files";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler (this.buttonParse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All files|*.*";
            this.openFileDialog.Multiselect = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size (334, 311);
            this.Controls.Add (this.buttonParse);
            this.Controls.Add (this.listBoxFiles);
            this.Name = "FormMain";
            this.Text = "Auto-Indentation Tool";
            this.contextMenuStripFilesList.ResumeLayout (false);
            this.ResumeLayout (false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFilesList;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

