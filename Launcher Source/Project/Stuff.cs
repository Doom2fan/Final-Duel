using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.IO;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace Launcher {
	public class Trilean {
		public static readonly Trilean Indeterminate;
		public static readonly Trilean False;
		public static readonly Trilean True;

		public static Trilean Parse (string tri) {
			if (tri.Contains ("False"))
				return Trilean.False;
			else if (tri.Contains ("True"))
				return Trilean.True;
			else
				return Trilean.Indeterminate;
		}

	}

	public class Game {
		public static bool Running = false;
		public static int ProcessID = 0;

		public static Config Configurations = new Config ();
	}

	public static class Utils {
		/// <summary>
		/// Displays an error window
		/// </summary>
		/// <param name="text">The text of the window</param>
		/// <param name="caption">The caption of the window</param>
		public static void ShowError (string text, string caption = "Error") {
			MessageBox.Show (text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// Displays an exception
		/// </summary>
		/// <param name="e">The exception to display</param>
		public static void ShowError (Exception e) {
			FormShowException form = new FormShowException ();
			form.ShowException (e);
		}

		public partial class FormShowException : Form {
			#region ============ Controls ============

			Button buttonSave = new Button ();
			Button buttonDiscard = new Button ();

			GroupBox groupBox1 = new GroupBox ();
			RadioButton radioButtonContinue = new RadioButton ();
			RadioButton radioButtonQuit = new RadioButton ();

			TabControl tabControl1 = new TabControl ();
			TabPage tabPage1 = new TabPage ();
			TextBox richTextBoxExceptionOverview = new TextBox ();

			SaveFileDialog SaveReportDialog = new SaveFileDialog ();

			#endregion

			#region ============ Intialization code ============

			public FormShowException () {
				// buttonSave
				buttonSave.Text = "Save report";
				buttonSave.Size = new Size (72, 23);
				buttonSave.Location = new Point (540, 398);
				buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				buttonSave.Click += buttonSave_Click;
				buttonSave.DialogResult = DialogResult.OK;

				// buttonDiscard
				buttonDiscard.Text = "Discard report";
				buttonDiscard.Size = new Size (83, 23);
				buttonDiscard.Location = new Point (451, 398);
				buttonDiscard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				buttonSave.DialogResult = DialogResult.Abort;

				// groupBox1
				groupBox1.Text = "Action";
				groupBox1.Size = new Size (130, 47);
				groupBox1.Location = new Point (315, 382);
				groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
				groupBox1.Controls.Add (radioButtonContinue);
				groupBox1.Controls.Add (radioButtonQuit);

				// radioButtonContinue
				radioButtonContinue.Text = "Continue";
				radioButtonContinue.AutoSize = true;
				radioButtonContinue.Size = new Size (67, 17);
				radioButtonContinue.Location = new Point (6, 19);
				radioButtonContinue.TabStop = true;

				// radioButtonQuit
				radioButtonQuit.Text = "Quit";
				radioButtonQuit.AutoSize = true;
				radioButtonQuit.Size = new Size (44, 17);
				radioButtonQuit.Location = new Point (79, 19);
				radioButtonQuit.Checked = true;
				radioButtonQuit.TabStop = true;

				// tabControl1
				tabControl1.AutoSize = false;
				tabControl1.Size = new Size (624, 376);
				tabControl1.Dock = DockStyle.Top;
				tabControl1.Controls.Add (tabPage1);

				// tabPage1
				tabPage1.Text = "Overview";
				tabPage1.Size = new Size (616, 350);
				tabPage1.Location = new Point (4, 22);
				tabPage1.Padding = new Padding (3);
				tabPage1.Controls.Add (richTextBoxExceptionOverview);

				// richTextBoxExceptionOverview
				richTextBoxExceptionOverview.Dock = DockStyle.Fill;
				richTextBoxExceptionOverview.Multiline = true;
				richTextBoxExceptionOverview.ReadOnly = true;

				// SaveReportDialog
				SaveReportDialog.FileName = "Report.zip";
				SaveReportDialog.Filter = "*.zip|Zip files";
				SaveReportDialog.Title = "Choose report file location...";
				SaveReportDialog.DefaultExt = "zip";

				// form
				this.Text = "An exception has ocurred";
				this.ClientSize = new Size (624, 441);
				this.AutoScaleDimensions = new SizeF (6F, 13F);
				this.AutoScaleMode = AutoScaleMode.Font;
				this.Controls.AddRange (new Control [] { tabControl1, groupBox1, buttonDiscard, buttonSave });
				this.FormBorderStyle = FormBorderStyle.FixedSingle;
				this.StartPosition = FormStartPosition.CenterScreen;
				this.ControlBox = false;
			}

			#endregion

			#region ============ Events ============

			private static void buttonSave_Click (object sender, EventArgs e) {
				
			}
			
			#endregion

			public void ShowException (Exception e) {
				this.richTextBoxExceptionOverview.Text = e.Message + Environment.NewLine + e.StackTrace + Environment.NewLine + e.InnerException;
				if (this.ShowDialog () == DialogResult.OK) {
					if (SaveReportDialog.ShowDialog () == DialogResult.OK) {

					}
				} else {
				}
			}
		}

		/// <summary>
		/// Functions for manipulating zip files
		/// </summary>
		public static class Zip {
			/// <summary>
			/// Extracts a zip file
			/// </summary>
			/// <param name="archiveFilenameIn">The path to the zip file.</param>
			/// <param name="outFolder">The path of the folder that the contents of the zip file will be extracted to.</param>
			/// <param name="FileName">Name of the file that will be extracted</param>
			public static void ExtractZip (string archiveFilenameIn, string outFolder, string FileName = null) {
				ZipFile zf = null;
				try {
					FileStream fs = File.OpenRead (archiveFilenameIn);
					zf = new ZipFile (fs);
					foreach (ZipEntry zipEntry in zf) {
						if (!zipEntry.IsFile || FileName != null && !zipEntry.Name.Equals (FileName))
							continue;
						string entryFileName = zipEntry.Name;

						byte [] buffer = new byte [4096]; //4K is optimum
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
		}
	}
}