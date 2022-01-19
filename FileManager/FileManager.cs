using System;
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
            button_desktop.BackColor = primary;
            button_desktop.ForeColor = text;
            button_music.BackColor = primary;
            button_music.ForeColor = text;
            button_videos.BackColor = primary;
            button_videos.ForeColor = text;
            button_myDocuments.BackColor = primary;
            button_myDocuments.ForeColor = text;
            button_pictures.BackColor = primary;
            button_pictures.ForeColor = text;
            current_location_container.BackColor = secondary;
            panel2.BackColor = primary;

            // Load the files in the default directory on the screen
            if (!isLoaded)
            {
                openDirectory(currentLocation);
            }
            isLoaded = true;
        }

        private void SearchText(object sender, MouseEventArgs e)
        {
            //if (textbox_search.Text == "Search Tags...")
            //    textbox_search.Text = "";
            //else if (string.IsNullOrWhiteSpace(textbox_search.Text))
            //    textbox_search.Text = "Search Tags...";
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

            panel_filesList.Controls.Clear();
            label_currentLocation.Text = currentLocation;
            
            displayFilesList(new List<string>(currentDirectories));
            displayFilesList(new List<string>(currentFiles));
        }

        private void displayFilesList(List<string> filesDirectoriesList)
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

                    //// Icon infront of each item
                    Button newBtn = createButton(text: "", width: 100, name: filesDirectoriesList[i]);
                    FileAttributes attr = File.GetAttributes(filesDirectoriesList[i]);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                        newBtn.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\folder-icon.png");
                    else
                        newBtn.Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + "\\icons\\pdf-icon.png"); //ToDo different extensions
                    
                    panel_filesList.Controls.Add(newBtn);

                    // Space
                    newBtn = createButton(text: "", width: 25, name: filesDirectoriesList[i]);
                    panel_filesList.Controls.Add(newBtn);

                    // File/Folder Name
                    newBtn = createButton(text: fileName, width: 550, name: filesDirectoriesList[i], padding: new Padding(24,0,0,0), isHoverEnabled: true);
                    newBtn.Click += button_Click_Open;
                    panel_filesList.Controls.Add(newBtn);

                    // Space
                    newBtn = createButton(text: "", width: 25, name: filesDirectoriesList[i]);
                    panel_filesList.Controls.Add(newBtn);

                    // Date Modified
                    newBtn = createButton(text: fileInfo.LastWriteTime.ToString(), width: 400, name: filesDirectoriesList[i]);
                    panel_filesList.Controls.Add(newBtn);

                    // Size
                    try {
                        newBtn = createButton(text: fileInfo.Length.ToString(), width: 200, name: filesDirectoriesList[i]);
                    }
                    catch { 
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
            Button button = (Button)sender;
            isSearching = true;
            string searchString = button.Text;

            if (searchString.IndexOf("#") == 0)
                searchString = searchString.Substring(1, searchString.Length - 1);

            if (tagsDictionary.ContainsKey(searchString))
            {
                panel_filesList.Controls.Clear();
                displayFilesList(tagsDictionary[searchString]);
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

       
    }
}
