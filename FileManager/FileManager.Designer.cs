namespace FileManager
{
    partial class FileManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.panel_filesList = new System.Windows.Forms.FlowLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.button_desktop = new System.Windows.Forms.Button();
            this.button_music = new System.Windows.Forms.Button();
            this.button_myDocuments = new System.Windows.Forms.Button();
            this.button_videos = new System.Windows.Forms.Button();
            this.button_pictures = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_tagsList = new System.Windows.Forms.FlowLayoutPanel();
            this.current_location_container = new System.Windows.Forms.Button();
            this.current_location = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_currentLocation = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.text_searchAll = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textbox_search = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_filesList
            // 
            this.panel_filesList.AutoScroll = true;
            this.panel_filesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel_filesList.Location = new System.Drawing.Point(567, 452);
            this.panel_filesList.Margin = new System.Windows.Forms.Padding(0);
            this.panel_filesList.Name = "panel_filesList";
            this.panel_filesList.Size = new System.Drawing.Size(1963, 881);
            this.panel_filesList.TabIndex = 0;
            this.panel_filesList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.backButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(504, 347);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(144, 69);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button_desktop
            // 
            this.button_desktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.button_desktop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_desktop.FlatAppearance.BorderSize = 0;
            this.button_desktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_desktop.ForeColor = System.Drawing.SystemColors.Control;
            this.button_desktop.Location = new System.Drawing.Point(34, 158);
            this.button_desktop.Name = "button_desktop";
            this.button_desktop.Size = new System.Drawing.Size(167, 62);
            this.button_desktop.TabIndex = 3;
            this.button_desktop.Text = "Desktop";
            this.button_desktop.UseVisualStyleBackColor = false;
            this.button_desktop.Click += new System.EventHandler(this.button_desktop_Click);
            // 
            // button_music
            // 
            this.button_music.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_music.FlatAppearance.BorderSize = 0;
            this.button_music.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_music.ForeColor = System.Drawing.Color.White;
            this.button_music.Location = new System.Drawing.Point(479, 158);
            this.button_music.Name = "button_music";
            this.button_music.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_music.Size = new System.Drawing.Size(129, 62);
            this.button_music.TabIndex = 4;
            this.button_music.Text = "Music";
            this.button_music.UseVisualStyleBackColor = true;
            this.button_music.Click += new System.EventHandler(this.button_music_Click);
            // 
            // button_myDocuments
            // 
            this.button_myDocuments.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_myDocuments.FlatAppearance.BorderSize = 0;
            this.button_myDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_myDocuments.ForeColor = System.Drawing.SystemColors.Control;
            this.button_myDocuments.Location = new System.Drawing.Point(218, 158);
            this.button_myDocuments.Name = "button_myDocuments";
            this.button_myDocuments.Size = new System.Drawing.Size(237, 62);
            this.button_myDocuments.TabIndex = 5;
            this.button_myDocuments.Text = "My Documents";
            this.button_myDocuments.UseVisualStyleBackColor = true;
            this.button_myDocuments.Click += new System.EventHandler(this.button_myDocuments_Click);
            // 
            // button_videos
            // 
            this.button_videos.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_videos.FlatAppearance.BorderSize = 0;
            this.button_videos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_videos.ForeColor = System.Drawing.SystemColors.Control;
            this.button_videos.Location = new System.Drawing.Point(848, 158);
            this.button_videos.Name = "button_videos";
            this.button_videos.Size = new System.Drawing.Size(139, 62);
            this.button_videos.TabIndex = 6;
            this.button_videos.Text = "Videos";
            this.button_videos.UseVisualStyleBackColor = true;
            this.button_videos.Click += new System.EventHandler(this.button_videos_Click);
            // 
            // button_pictures
            // 
            this.button_pictures.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_pictures.FlatAppearance.BorderSize = 0;
            this.button_pictures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pictures.ForeColor = System.Drawing.SystemColors.Control;
            this.button_pictures.Location = new System.Drawing.Point(657, 158);
            this.button_pictures.Name = "button_pictures";
            this.button_pictures.Size = new System.Drawing.Size(131, 62);
            this.button_pictures.TabIndex = 7;
            this.button_pictures.Text = "Pictures";
            this.button_pictures.UseVisualStyleBackColor = true;
            this.button_pictures.Click += new System.EventHandler(this.button_pictures_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button_videos);
            this.panel2.Controls.Add(this.button_music);
            this.panel2.Controls.Add(this.button_pictures);
            this.panel2.Controls.Add(this.button_desktop);
            this.panel2.Controls.Add(this.button_myDocuments);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2529, 233);
            this.panel2.TabIndex = 11;
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel9.BackgroundImage")));
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Location = new System.Drawing.Point(688, 90);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(65, 62);
            this.panel9.TabIndex = 5;
            this.panel9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel8.BackgroundImage")));
            this.panel8.Location = new System.Drawing.Point(885, 90);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(65, 62);
            this.panel8.TabIndex = 4;
            this.panel8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel7.BackgroundImage")));
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel7.Location = new System.Drawing.Point(506, 90);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(62, 62);
            this.panel7.TabIndex = 3;
            this.panel7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.Location = new System.Drawing.Point(311, 90);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(65, 62);
            this.panel6.TabIndex = 2;
            this.panel6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.Location = new System.Drawing.Point(84, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(64, 62);
            this.panel5.TabIndex = 1;
            this.panel5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(48, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 32);
            this.label4.TabIndex = 25;
            this.label4.Text = "Quick Links";
            this.label4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // panel_tagsList
            // 
            this.panel_tagsList.AutoScroll = true;
            this.panel_tagsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel_tagsList.Location = new System.Drawing.Point(1, 335);
            this.panel_tagsList.Margin = new System.Windows.Forms.Padding(0);
            this.panel_tagsList.Name = "panel_tagsList";
            this.panel_tagsList.Size = new System.Drawing.Size(500, 1013);
            this.panel_tagsList.TabIndex = 1;
            this.panel_tagsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            // 
            // current_location_container
            // 
            this.current_location_container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.current_location_container.Enabled = false;
            this.current_location_container.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.current_location_container.Location = new System.Drawing.Point(1, 231);
            this.current_location_container.Name = "current_location_container";
            this.current_location_container.Size = new System.Drawing.Size(2526, 108);
            this.current_location_container.TabIndex = 16;
            this.current_location_container.UseVisualStyleBackColor = false;
            // 
            // current_location
            // 
            this.current_location.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.current_location.Enabled = false;
            this.current_location.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.current_location.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.current_location.ForeColor = System.Drawing.Color.White;
            this.current_location.Location = new System.Drawing.Point(507, 239);
            this.current_location.Name = "current_location";
            this.current_location.Size = new System.Drawing.Size(1410, 94);
            this.current_location.TabIndex = 17;
            this.current_location.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(528, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(65, 62);
            this.panel1.TabIndex = 0;
            // 
            // label_currentLocation
            // 
            this.label_currentLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label_currentLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label_currentLocation.ForeColor = System.Drawing.Color.White;
            this.label_currentLocation.Location = new System.Drawing.Point(611, 271);
            this.label_currentLocation.Name = "label_currentLocation";
            this.label_currentLocation.Size = new System.Drawing.Size(1250, 31);
            this.label_currentLocation.TabIndex = 0;
            this.label_currentLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_currentLocation);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1923, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(593, 94);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Location = new System.Drawing.Point(1960, 252);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(60, 62);
            this.panel3.TabIndex = 1;
            // 
            // text_searchAll
            // 
            this.text_searchAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.text_searchAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_searchAll.ForeColor = System.Drawing.Color.DimGray;
            this.text_searchAll.Location = new System.Drawing.Point(2044, 269);
            this.text_searchAll.Name = "text_searchAll";
            this.text_searchAll.Size = new System.Drawing.Size(456, 31);
            this.text_searchAll.TabIndex = 19;
            this.text_searchAll.Text = "Search folder...";
            this.text_searchAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchFolder_clicked);
            this.text_searchAll.KeyUp += new System.Windows.Forms.KeyEventHandler(this.button_searchFolders);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(4, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(497, 94);
            this.button2.TabIndex = 20;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textbox_search
            // 
            this.textbox_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.textbox_search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_search.ForeColor = System.Drawing.Color.DimGray;
            this.textbox_search.Location = new System.Drawing.Point(111, 269);
            this.textbox_search.Name = "textbox_search";
            this.textbox_search.Size = new System.Drawing.Size(327, 31);
            this.textbox_search.TabIndex = 20;
            this.textbox_search.Text = "Search tags...";
            this.textbox_search.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchTags_clicked);
            this.textbox_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.button_filterTagsSidebar_Search);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Location = new System.Drawing.Point(27, 252);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(60, 62);
            this.panel4.TabIndex = 2;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.ForeColor = System.Drawing.Color.Gray;
            this.label_name.Location = new System.Drawing.Point(699, 366);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(90, 32);
            this.label_name.TabIndex = 21;
            this.label_name.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(1669, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 32);
            this.label1.TabIndex = 22;
            this.label1.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(1868, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 32);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tags";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(1272, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 32);
            this.label3.TabIndex = 24;
            this.label3.Text = "Date Modified";
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(2528, 1352);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.textbox_search);
            this.Controls.Add(this.text_searchAll);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_currentLocation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_tagsList);
            this.Controls.Add(this.panel_filesList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.current_location);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.current_location_container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FileManager";
            this.Text = "File Manager";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resetPlaceholders);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel_filesList;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button button_desktop;
        private System.Windows.Forms.Button button_music;
        private System.Windows.Forms.Button button_myDocuments;
        private System.Windows.Forms.Button button_videos;
        private System.Windows.Forms.Button button_pictures;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel panel_tagsList;
        private System.Windows.Forms.Button current_location_container;
        private System.Windows.Forms.Button current_location;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox label_currentLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox text_searchAll;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textbox_search;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
    }
}

