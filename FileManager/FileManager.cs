﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FileManager : Form
    {
        bool isLoaded = false;
        bool isSearching = false;
        string currentLocation = "";
        string[] currentDirectories;
        string[] currentFiles;

        enum Folder {
            MyDocuments,
            MyMusic,
            MyPictures,
            MyVideos,
            Desktop
        }

        Dictionary<Folder, string> SpecialFolders = new Dictionary<Folder, string>(){
            {Folder.MyDocuments, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)},
            {Folder.MyMusic, Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)},
            {Folder.MyPictures, Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)},
            {Folder.MyVideos, Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)},
            {Folder.Desktop, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)},
        };
        
        Dictionary<string, List<string>> tagsDictionary = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> filesDictionary = new Dictionary<string, List<string>>();

        public FileManager()
        {
            // Initialize form
            InitializeComponent();
            this.Size = new Size(2560, 1440);

            // Default location is the Desktop
            currentLocation = SpecialFolders[Folder.Desktop];
            currentDirectories = Directory.GetDirectories(SpecialFolders[Folder.Desktop]);
            currentFiles = Directory.GetFiles(SpecialFolders[Folder.Desktop]);
            label_currentLocation.Text = currentLocation;

            // Load the files in the default directory on the screen
            if (!isLoaded)
            {
                openDirectory(currentLocation);
            }
            isLoaded = true;
        }

        private void button_Click_Open(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string filePath = button.Name;

            try
            {
                // If a directory clicked, reload list of files in new directory
                openDirectory(filePath);
            }
            catch(Exception ex)
            {
                // If file clicked, open the file
                var process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = filePath };
                process.Start();
            }
        }

        private void openDirectory(string filePath)
        {
            // Change current location, and files to be shown in UI
            currentLocation = filePath;
            currentDirectories = Directory.GetDirectories(filePath);
            currentFiles = Directory.GetFiles(filePath);

            flowLayoutPanel1.Controls.Clear();
            label_currentLocation.Text = currentLocation;
            
            displayFilesList(new List<string>(currentDirectories));
            displayFilesList(new List<string>(currentFiles));
        }

        private void displayFilesList(List<string> filesDirectoriesList)
        {
            // Show all the unhidden files in the directory
            for (int i = 0; i < filesDirectoriesList.Count; i++)
            {
                bool isHidden = ((File.GetAttributes(filesDirectoriesList[i]) & FileAttributes.Hidden) == FileAttributes.Hidden);

                if (!isHidden)
                { 
                    // Get the name of the file from the path
                    var startOfName = filesDirectoriesList[i].LastIndexOf("\\");
                    var fileName = filesDirectoriesList[i].Substring(startOfName + 1, filesDirectoriesList[i].Length - (startOfName + 1));

                    // Icon infront of each item
                    Button newBtn = createButton("", 100, 100, new Padding(0, 0, 0, 0), FlatStyle.Flat, ContentAlignment.MiddleCenter, 0, filesDirectoriesList[i], false);
                    FileAttributes attr = File.GetAttributes(filesDirectoriesList[i]);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                        newBtn.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\folder-icon.png");
                    else
                        newBtn.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\pdf-icon.png"); //ToDo different extensions
                    
                    flowLayoutPanel1.Controls.Add(newBtn);

                    // File/Folder Name
                    newBtn = createButton(fileName, 100, 800, new Padding(0, 0, 0, 0), FlatStyle.Flat, ContentAlignment.MiddleLeft, 0, filesDirectoriesList[i], true);
                    newBtn.Click += button_Click_Open;
                    flowLayoutPanel1.Controls.Add(newBtn);

                    // Size
                    newBtn = createButton("200kb", 100, 200, new Padding(0, 0, 0, 0), FlatStyle.Flat, ContentAlignment.MiddleCenter, 0, filesDirectoriesList[i], false);
                    flowLayoutPanel1.Controls.Add(newBtn);
                    
                    // Date Modified
                    newBtn = createButton("23/23/23", 100, 200, new Padding(0, 0, 0, 0), FlatStyle.Flat, ContentAlignment.MiddleCenter, 0, filesDirectoriesList[i], false);
                    flowLayoutPanel1.Controls.Add(newBtn);
                    
                    // #List of tags
                    string btnText = "No Tags";
                    if (filesDictionary.ContainsKey(filesDirectoriesList[i]))
                    {
                        if (filesDictionary[filesDirectoriesList[i]].Count != 0)
                        {
                            btnText = $" ● ";
                            foreach (var tag in filesDictionary[filesDirectoriesList[i]])
                            {
                                btnText += $" #{tag} ● ";
                            }
                        }
                    }
                    newBtn = createButton(btnText, 100, 800, new Padding(0, 0, 0, 0), FlatStyle.Flat, ContentAlignment.MiddleLeft, 0, filesDirectoriesList[i], true);
                    newBtn.Click += button_Click_Manage_Tag;
                    newBtn.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\add-icon.png"); // Change to plus
                    newBtn.ImageAlign = ContentAlignment.MiddleRight;
                    flowLayoutPanel1.Controls.Add(newBtn);
                }
            }
        }

        private Button createButton(string text, int height, int width, Padding margin, FlatStyle flatStyle, ContentAlignment textAlign, int borderSize, string name, bool isHoverEnabled)
        {
            Button button = new Button();
            button.Text = text;
            button.Height = height;
            button.Width = width;
            button.Margin = margin;
            button.FlatStyle = flatStyle;
            button.TextAlign = textAlign;
            button.FlatAppearance.BorderSize = borderSize;
            button.Name = name;
            if (!isHoverEnabled)
            {
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.BackColorChanged += (s, e) => {
                    button.FlatAppearance.MouseOverBackColor = button.BackColor;
                };
            }
            return button;
        }

        private void button_Click_Manage_Tag(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string filePath = button.Name;
            
            // Displays the MessageBox
            string value = "";
            if (InputBox("New Tag", "New Tag name:", ref value) == DialogResult.OK)
            {
                // Add tags to dictionaries
                if (!filesDictionary.ContainsKey(filePath)) {
                    filesDictionary.Add(filePath, new List<string>() { value });
                }
                else
                {
                    if (filesDictionary[filePath].IndexOf(value) < 0)
                        filesDictionary[filePath].Add(value);
                }
                if (!tagsDictionary.ContainsKey(value))
                {
                    tagsDictionary.Add(value, new List<string>() { filePath });
                }
                else
                {
                    if (tagsDictionary[value].IndexOf(filePath) < 0)
                        tagsDictionary[value].Add(filePath);
                }

                // #Tag changes on the UI
                if (filesDictionary[filePath].Count != 0)
                {
                    button.Text = "●";
                    foreach (var tag in filesDictionary[filePath])
                    {
                        button.Text += $" #{tag} ● ";
                    }
                }
            }
        }

        private void button_searchTags_Click(object sender, EventArgs e)
        {
            isSearching = true;
            
            if (tagsDictionary.ContainsKey(textbox_search.Text))
            {
                // Display only files with searched tag
                flowLayoutPanel1.Controls.Clear();
                displayFilesList(tagsDictionary[textbox_search.Text]);
            }
            else
            {
                openDirectory(this.currentLocation);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            // Go up one folder level
            if (!isSearching)
            {
                var previousFolder = this.currentLocation.Substring(0, this.currentLocation.LastIndexOf("\\"));
                openDirectory(previousFolder);
            }
            else
            {
                openDirectory(this.currentLocation);
                isSearching = false;
            }
        }

        // Open directories of special folders (MyDocuments, Videos, etc)
        private void button_desktop_Click(object sender, EventArgs e)
        {
            openDirectory(SpecialFolders[Folder.Desktop]);
        }

        private void button_myDocuments_Click(object sender, EventArgs e)
        {
            openDirectory(SpecialFolders[Folder.MyDocuments]);
        }

        private void button_music_Click(object sender, EventArgs e)
        {
            openDirectory(SpecialFolders[Folder.MyMusic]);
        }

        private void button_pictures_Click(object sender, EventArgs e)
        {
            openDirectory(SpecialFolders[Folder.MyPictures]);
        }

        private void button_videos_Click(object sender, EventArgs e)
        {
            openDirectory(SpecialFolders[Folder.MyVideos]);
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            // ToDo fix alignment
            label.SetBounds(36, 36, 372, 13);
            textBox.SetBounds(36, 86, 560, 20);
            buttonOk.SetBounds(228, 160, 160, 60);
            buttonCancel.SetBounds(400, 160, 160, 60);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(796, 307);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}