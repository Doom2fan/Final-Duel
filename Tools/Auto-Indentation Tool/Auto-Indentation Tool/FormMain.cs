using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Auto_Indentation_Tool {
    public partial class FormMain : Form {
        public FormMain () {
            InitializeComponent ();
        }


        private void buttonParse_Click (object sender, EventArgs e) {
            Task ParseFiles = new Task (delegate {
                foreach (string file in listBoxFiles.Items) {
                    List<string> Input = new List<string> ();
                    List<string> Output = new List<string> ();
                    bool InActor = false;
                    bool InStates = false;
                    try {
                        Input.AddRange (File.ReadAllLines (file));
                    } catch {
                        MessageBox.Show ("File is in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } finally {

                        foreach (string line in Input) {
                            string parsedline = line;

                            if (line.Contains ('}') && InStates)
                                InStates = false;
                            else if (line.Contains ('}') && InActor)
                                InActor = false;

                            // Trim spaces and tab characters from the start and end of the line
                            parsedline = parsedline.Trim ();

                            // Insert a space after commas
                            parsedline = parsedline.Replace (", ", ",");
                            parsedline = parsedline.Replace (",", ", ");

                            // Insert a space before '('s
                            parsedline = parsedline.Replace (" (", "(");
                            parsedline = parsedline.Replace ("(", " (");

                            // Add tab characters if we're parsing an actor
                            if (InActor)
                                parsedline = parsedline.Insert (0, "\t");
                            if (InStates && !parsedline.EndsWith (":"))
                                parsedline = parsedline.Insert (0, "\t");

                            Debug.WriteLine (Regex.IsMatch (parsedline, "(\t\b:)").ToString ());

                            // Add a newline character to the end of the line
                            parsedline += '\n';

                            Debug.WriteLine (parsedline);
                            Output.Add (parsedline);

                            if (line.Contains ('{') && !InActor)
                                InActor = true;
                            else if (line.Contains ('{') && !InStates && InActor)
                                InStates = true;

                            if (line.Contains ('}') && InStates)
                                InStates = false;
                            else if (line.Contains ('}') && InActor)
                                InActor = false;
                        }

                        List<byte> OutputBytes = new List<byte> ();

                        List<char> charList = new List<char> ();

                        foreach (string line in Output)
                            foreach (char character in line)
                                charList.Add (character);

                        foreach (char character in charList)
                            OutputBytes.Add (Convert.ToByte (character));

                        try {
                            File.WriteAllBytes (file, OutputBytes.ToArray ());
                        } catch {
                            MessageBox.Show ("File is in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            });

            ParseFiles.Start ();
        }

        private void filesToolStripMenuItem_Click (object sender, EventArgs e) {
            if (openFileDialog.ShowDialog () == DialogResult.OK)
                listBoxFiles.Items.AddRange (openFileDialog.FileNames);
        }

        private void folderToolStripMenuItem_Click (object sender, EventArgs e) {
            if (folderBrowserDialog.ShowDialog () == DialogResult.OK) {
                string[] Files;
                string SelectedPath = folderBrowserDialog.SelectedPath;
                string searchPattern = string.Empty;

                if (Stuff.InputBox ("Input filename", "Input the name of files\n(Use \"*\" to add all files and \"*.<extension>\" to add all files with a certain extension)", ref searchPattern) == DialogResult.OK) {
                    if (searchPattern.Equals (""))
                        searchPattern = "*";

                    Files = Directory.GetFiles (SelectedPath, searchPattern, SearchOption.AllDirectories);

                    foreach (string file in Files) {
                        listBoxFiles.Items.Add (file);
                    }
                }
            }
        }

        private void listBoxFiles_KeyDown (object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete && listBoxFiles.SelectedIndex >= 0)
                listBoxFiles.Items.RemoveAt (listBoxFiles.SelectedIndex);
        }
    }
}