using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            // Additional Styling to controls
            Color primary = Color.FromArgb(32, 32, 32);
            Color secondary = Color.FromArgb(25, 25, 25);
            Color text = Color.FromArgb(150, 150, 150);
            
            this.BackColor = primary;
            panel_tagsList.BackColor = secondary;
            textbox_search.BackColor = secondary;
            //textbox_search.ForeColor = Color.FromArgb(109, 107, 107); // ToDo add grey search tags
            textbox_search.ForeColor = text;
            button2.BackColor = secondary;
            backButton.BackColor = primary;
            backButton.ForeColor = text;
            button_desktop.BackColor = secondary;
            button_desktop.ForeColor = text;
            button_music.BackColor = secondary;
            button_music.ForeColor = text;
            button_videos.BackColor = secondary;
            button_videos.ForeColor = text;
            button_myDocuments.BackColor = secondary;
            button_myDocuments.ForeColor = text;
            button_pictures.BackColor = secondary;
            button_pictures.ForeColor = text;
            panel2.BackColor = secondary;

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
            resetPlaceholders();

            // Change current location, and files to be shown in UI
            currentLocation = filePath;
            currentDirectories = Directory.GetDirectories(filePath);
            currentFiles = Directory.GetFiles(filePath);
            
            // Gets what should be written at the top filepath
            string currentDir = Path.GetFileName(currentLocation);
            label_currentLocation.Text = currentLocation.Remove(currentLocation.IndexOf(currentDir)-1);
            currentDir_heading.Text = "\\"+currentDir;
            
            panel_filesList.Controls.Clear();

            displayFilesList(new List<string>(currentDirectories), "");
            displayFilesList(new List<string>(currentFiles), "");
        }

        private void displayFilesList(List<string> filesDirectoriesList, string searchString)
        {
            // Show all the unhidden files in the directory
            for (int i = 0; i < filesDirectoriesList.Count; i++)
            {
                var fileInfo = new System.IO.FileInfo(filesDirectoriesList[i]);
                System.IO.DriveInfo driveInfo = new System.IO.DriveInfo(filesDirectoriesList[i]);
                bool isHidden = ((File.GetAttributes(filesDirectoriesList[i]) & FileAttributes.Hidden) == FileAttributes.Hidden);

                if (!isHidden)
                { 
                    // Get the name of the file from the path
                    var startOfName = filesDirectoriesList[i].LastIndexOf("\\");
                    var fileName = filesDirectoriesList[i].Substring(startOfName + 1, filesDirectoriesList[i].Length - (startOfName + 1));

                    if (searchString.Equals("") || fileName.ToLower().IndexOf(searchString.ToLower()) >= 0)
                    {
                        // Icon infront of each item
                        Button newBtn = createButton(text: "", width: 100, name: filesDirectoriesList[i]);
                        FileAttributes attr = File.GetAttributes(filesDirectoriesList[i]);
                        if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                        {
                            newBtn.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\folder-icon.png");
                        }
                        else
                        {
                            string fileExt = Path.GetExtension(filesDirectoriesList[i]);
                            switch(fileExt)
                            {
                                case ".PNG":
                                case ".png":
                                case ".JPG":
                                case ".jpg":
                                case ".JPEG":
                                case ".jpeg":
                                    newBtn.Image = Image.FromFile(Environment.CurrentDirectory + "\\icons\\image-icon2.png"); 
                                    break;
                                case ".PDF":
                                case ".pdf":
                                    newBtn.Image = Image.FromFile(Environment.CurrentDirectory + "\\icons\\pdf-icon2.png");
                                    break;
                                case ".doc":
                                case ".DOC":
                                case ".docx":
                                case ".DOCX":
                                    newBtn.Image = Image.FromFile(Environment.CurrentDirectory + "\\icons\\word-icon.png");
                                    break;
                                case ".TXT":
                                case ".txt":
                                    newBtn.Image = Image.FromFile(Environment.CurrentDirectory + "\\icons\\text-icon.png");
                                    break;
                                default:
                                    newBtn.Image = Image.FromFile(Environment.CurrentDirectory + "\\icons\\pdf-icon2.png");
                                    break;
                            }
                        }

                        panel_filesList.Controls.Add(newBtn);

                        // Space
                        newBtn = createButton(text: "", width: 25, name: filesDirectoriesList[i]);
                        panel_filesList.Controls.Add(newBtn);

                        // File/Folder Name
                        newBtn = createButton(text: fileName, width: 550, name: filesDirectoriesList[i], padding: new Padding(24, 0, 0, 0), isHoverEnabled: true);
                        newBtn.Click += button_Click_Open;
                        panel_filesList.Controls.Add(newBtn);

                        // Space
                        newBtn = createButton(text: "", width: 25, name: filesDirectoriesList[i]);
                        panel_filesList.Controls.Add(newBtn);

                        // Date Modified
                        newBtn = createButton(text: fileInfo.LastWriteTime.ToString(), width: 400, name: filesDirectoriesList[i]);
                        panel_filesList.Controls.Add(newBtn);

                        // Size
                        try
                        {
                            newBtn = createButton(text: fileInfo.Length.ToString(), width: 200, name: filesDirectoriesList[i]);
                        }
                        catch
                        {
                            newBtn = createButton(text: "", width: 200, name: filesDirectoriesList[i]);
                        }
                        panel_filesList.Controls.Add(newBtn);

                        // #List of tags
                        string btnText = listTagsForFile(filesDirectoriesList[i]);
                        newBtn = createButton(text: btnText, width: 600, name: filesDirectoriesList[i], textAlign: ContentAlignment.MiddleLeft);
                        newBtn.Click += button_Click_Manage_Tag;
                        newBtn.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\edit-blue.png"); // Change to plus
                        newBtn.ImageAlign = ContentAlignment.MiddleRight;
                        newBtn.MouseEnter += new System.EventHandler(this.button_MouseHover);
                        newBtn.MouseLeave += new System.EventHandler(this.button_MouseLeave);
                        panel_filesList.Controls.Add(newBtn);
                    }
                }
            }
        }

        private void button_MouseHover(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\edit-green.png");
        }

        private void button_MouseLeave(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\edit-blue.png");
        }

        private string listTagsForFile(string key, string btnText = "No Tags")
        {
            // #List of tags
            if (filesDictionary.ContainsKey(key))
            {
                btnText = $"";
                foreach (var tag in filesDictionary[key])
                {
                    if (btnText.Length <= 25 && btnText.Equals(""))
                        btnText += $" #{tag}";
                    else if (btnText.Length <= 25)
                        btnText += $" ● #{tag}";
                    else if (btnText.Length > 25 && btnText.LastIndexOf(@"...") < 0)
                        btnText += " ...";
                }
            }
            return btnText;
        }

        private void button_Click_Manage_Tag(object sender, EventArgs e)
        {
            resetPlaceholders();
            Button button = (Button)sender;
            string filePath = button.Name;

            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent

            // Displays the MessageBox
            string value = "";
            if (InputBox("New Tag", "New Tag name:", ref value) == DialogResult.OK)
            {
                if (value.Equals(""))
                {
                    return;
                }
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
                button.Text = listTagsForFile(filePath, button.Text);

                // Reload tags list in side panel
                panel_tagsList.Controls.Clear();
                int width = 500;
                if (tagsDictionary.Count > 9)
                    width = 450;

                foreach (var tag in tagsDictionary)
                {
                    Button newBtn = createButton(text: $"#{tag.Key}", width: width, padding: new Padding(100, 20, 100, 20), textAlign: ContentAlignment.MiddleLeft, name: tag.Key, isHoverEnabled: true);
                    newBtn.Click += button_searchTags_Click;
                    panel_tagsList.Controls.Add(newBtn);
                }
            }
        }

        private void button_filterTagsSidebar_Search(object sender, KeyEventArgs e)
        {
            TextBox textbox = (TextBox)sender;

            panel_tagsList.Controls.Clear();
            foreach (KeyValuePair<string, List<string>> tag in tagsDictionary)
            {
                int width = 500;
                if (tagsDictionary.Count > 9)
                    width = 450;

                // Reload tags list in side panel
                if (tag.Key.Contains(textbox_search.Text))
                {
                    Button newBtn = createButton(text: $"#{tag.Key}", width: width, padding: new Padding(100, 20, 100, 20), textAlign: ContentAlignment.MiddleLeft, name: tag.Key, isHoverEnabled: true);
                    newBtn.Click += button_searchTags_Click;
                    panel_tagsList.Controls.Add(newBtn);
                }
            }
        }

        private void button_searchTags_Click(object sender, EventArgs e)
        {
            resetPlaceholders();

            Button button = (Button)sender;
            isSearching = true;
            string searchString = button.Text;

            if (searchString.IndexOf("#") == 0)
                searchString = searchString.Substring(1, searchString.Length - 1);

            if (tagsDictionary.ContainsKey(searchString))
            {
                panel_filesList.Controls.Clear();
                displayFilesList(tagsDictionary[searchString], "");
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

        private Button createButton(
            string text = "",
            string name = "",
            int? height = 90,
            int? width = 300,
            Padding? margin = null,
            Padding? padding = null,
            FlatStyle? flatStyle = FlatStyle.Flat,
            ContentAlignment? textAlign = ContentAlignment.MiddleLeft,
            int? borderSize = 0,
            bool? isHoverEnabled = false)
        {
            if (margin == null)
                margin = new Padding(0, 0, 0, 0);
            if (padding == null)
                padding = new Padding(0, 0, 0, 0);

            Button button = new Button();
            button.ForeColor = Color.FromArgb(250, 250, 250);
            button.Text = text;
            button.Name = name;
            button.Height = (int)height;
            button.Width = (int)width;
            button.Margin = (Padding)margin;
            button.Padding = (Padding)padding;
            button.FlatStyle = (FlatStyle)flatStyle;
            button.TextAlign = (ContentAlignment)textAlign;
            button.FlatAppearance.BorderSize = (int)borderSize;
            if ((bool)!isHoverEnabled)
            {
                button.FlatAppearance.MouseOverBackColor = button.BackColor;
                button.BackColorChanged += (s, e) => {
                    button.FlatAppearance.MouseOverBackColor = button.BackColor;
                };
            }
            return button;
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

        private void searchTags_clicked(object sender, MouseEventArgs e)
        {
            resetPlaceholders();

            TextBox textbox = (TextBox)sender;
            if (textbox.Text.Equals("Search tags..."))
                textbox.Text = "";
        }

        private void searchFolder_clicked(object sender, MouseEventArgs e)
        {
            resetPlaceholders();

            TextBox textbox = (TextBox)sender;
            if (textbox.Text.Equals("Search folder..."))
                textbox.Text = "";
        }

        private void button_searchFolders(object sender, KeyEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string searchString = textbox.Text;

            currentDirectories = Directory.GetDirectories(this.currentLocation);
            currentFiles = Directory.GetFiles(this.currentLocation);

            panel_filesList.Controls.Clear();
            label_currentLocation.Text = currentLocation;

            displayFilesList(new List<string>(currentDirectories), searchString);
            displayFilesList(new List<string>(currentFiles), searchString);
        }

        private void resetPlaceholders(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            resetPlaceholders();
        }

        private void resetPlaceholders()
        {
            if (textbox_search.Text.Equals(""))
                textbox_search.Text = "Search tags...";

            if (text_searchAll.Text.Equals(""))
                text_searchAll.Text = "Search folder...";
            
        }

        private void search_currentLocation(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                TextBox textbox = (TextBox)sender;
                string searchString = textbox.Text;

                try
                {
                    currentLocation = searchString;
                    currentDirectories = Directory.GetDirectories(searchString);
                    currentFiles = Directory.GetFiles(searchString);
                    label_currentLocation.Text = currentLocation;
                }
                catch
                {
                    return;
                }

                Console.WriteLine("It goes through");
                openDirectory(currentLocation);
            }
        }

        private void currentPath_textchanged(object sender, EventArgs e)
        {
            // ToDo: Fix 
            TextBox textbox = (TextBox)sender as TextBox;

            // Find the name of the parent folder
            string currentDir = Path.GetFileName(currentLocation);
            string parentFolderPath = currentLocation.Remove(currentLocation.IndexOf(currentDir) - 1);
            string parent = Path.GetFileName(parentFolderPath);

            //if (textbox.Text.Equals(""))
            //{
            //    currentDir_heading.Text = "\\" + parent;
            //    label_currentLocation.Text = parentFolderPath.Remove(parentFolderPath.IndexOf(parent) - 1);
            //    currentLocation = parentFolderPath;
            //    openDirectory(currentLocation);
            //}
            //else if((textbox.Text.LastIndexOf("\\") == textbox.Text.Length-1) && textbox.Text.LastIndexOf("\\") != 0)
            //{
            //    currentDir_heading.Text = "\\";
            //    label_currentLocation.Text = currentLocation; 
            //}
            //else if((textbox.Text.LastIndexOf("/") == textbox.Text.Length - 1) && textbox.Text.LastIndexOf("/") != 0)
            //{
            //    currentDir_heading.Text = "\\";
            //    label_currentLocation.Text = currentLocation;
            //}
        }
    }
}
