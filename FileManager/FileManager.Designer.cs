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
            this.panel_filesList = new System.Windows.Forms.FlowLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.button_desktop = new System.Windows.Forms.Button();
            this.button_music = new System.Windows.Forms.Button();
            this.button_myDocuments = new System.Windows.Forms.Button();
            this.button_videos = new System.Windows.Forms.Button();
            this.button_pictures = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textbox_search = new System.Windows.Forms.TextBox();
            this.panel_tagsList = new System.Windows.Forms.FlowLayoutPanel();
            this.label_currentLocation = new System.Windows.Forms.Label();
            this.textbox_search_wrapper = new System.Windows.Forms.Button();
            this.textbox_search_container = new System.Windows.Forms.Button();
            this.current_location_container = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_filesList
            // 
            this.panel_filesList.AutoScroll = true;
            this.panel_filesList.Location = new System.Drawing.Point(567, 371);
            this.panel_filesList.Margin = new System.Windows.Forms.Padding(0);
            this.panel_filesList.Name = "panel_filesList";
            this.panel_filesList.Size = new System.Drawing.Size(1963, 972);
            this.panel_filesList.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(12, 212);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(174, 93);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button_desktop
            // 
            this.button_desktop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_desktop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_desktop.FlatAppearance.BorderSize = 0;
            this.button_desktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_desktop.Location = new System.Drawing.Point(3, 3);
            this.button_desktop.Name = "button_desktop";
            this.button_desktop.Size = new System.Drawing.Size(243, 197);
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
            this.button_music.Location = new System.Drawing.Point(237, 3);
            this.button_music.Name = "button_music";
            this.button_music.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_music.Size = new System.Drawing.Size(243, 197);
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
            this.button_myDocuments.Location = new System.Drawing.Point(719, 3);
            this.button_myDocuments.Name = "button_myDocuments";
            this.button_myDocuments.Size = new System.Drawing.Size(243, 197);
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
            this.button_videos.Location = new System.Drawing.Point(477, 3);
            this.button_videos.Name = "button_videos";
            this.button_videos.Size = new System.Drawing.Size(243, 197);
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
            this.button_pictures.Location = new System.Drawing.Point(961, 3);
            this.button_pictures.Name = "button_pictures";
            this.button_pictures.Size = new System.Drawing.Size(243, 197);
            this.button_pictures.TabIndex = 7;
            this.button_pictures.Text = "Pictures";
            this.button_pictures.UseVisualStyleBackColor = true;
            this.button_pictures.Click += new System.EventHandler(this.button_pictures_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_videos);
            this.panel2.Controls.Add(this.button_music);
            this.panel2.Controls.Add(this.button_pictures);
            this.panel2.Controls.Add(this.button_desktop);
            this.panel2.Controls.Add(this.button_myDocuments);
            this.panel2.Location = new System.Drawing.Point(9, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2521, 207);
            this.panel2.TabIndex = 11;
            // 
            // textbox_search
            // 
            this.textbox_search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_search.Location = new System.Drawing.Point(87, 362);
            this.textbox_search.Name = "textbox_search";
            this.textbox_search.Size = new System.Drawing.Size(330, 31);
            this.textbox_search.TabIndex = 0;
            this.textbox_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.button_filterTagsSidebar_Search);
            // 
            // panel_tagsList
            // 
            this.panel_tagsList.AutoScroll = true;
            this.panel_tagsList.Location = new System.Drawing.Point(-12, 450);
            this.panel_tagsList.Margin = new System.Windows.Forms.Padding(0);
            this.panel_tagsList.Name = "panel_tagsList";
            this.panel_tagsList.Size = new System.Drawing.Size(500, 911);
            this.panel_tagsList.TabIndex = 1;
            // 
            // label_currentLocation
            // 
            this.label_currentLocation.AutoSize = true;
            this.label_currentLocation.ForeColor = System.Drawing.Color.White;
            this.label_currentLocation.Location = new System.Drawing.Point(584, 243);
            this.label_currentLocation.Name = "label_currentLocation";
            this.label_currentLocation.Size = new System.Drawing.Size(93, 32);
            this.label_currentLocation.TabIndex = 0;
            this.label_currentLocation.Text = "label1";
            // 
            // textbox_search_wrapper
            // 
            this.textbox_search_wrapper.Enabled = false;
            this.textbox_search_wrapper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textbox_search_wrapper.Location = new System.Drawing.Point(1, 313);
            this.textbox_search_wrapper.Name = "textbox_search_wrapper";
            this.textbox_search_wrapper.Size = new System.Drawing.Size(487, 145);
            this.textbox_search_wrapper.TabIndex = 14;
            this.textbox_search_wrapper.UseVisualStyleBackColor = true;
            // 
            // textbox_search_container
            // 
            this.textbox_search_container.Enabled = false;
            this.textbox_search_container.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textbox_search_container.Location = new System.Drawing.Point(50, 334);
            this.textbox_search_container.Name = "textbox_search_container";
            this.textbox_search_container.Size = new System.Drawing.Size(404, 84);
            this.textbox_search_container.TabIndex = 15;
            this.textbox_search_container.UseVisualStyleBackColor = true;
            // 
            // current_location_container
            // 
            this.current_location_container.Enabled = false;
            this.current_location_container.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.current_location_container.Location = new System.Drawing.Point(1, 206);
            this.current_location_container.Name = "current_location_container";
            this.current_location_container.Size = new System.Drawing.Size(2526, 108);
            this.current_location_container.TabIndex = 16;
            this.current_location_container.UseVisualStyleBackColor = true;
            // 
            // FileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2528, 1352);
            this.Controls.Add(this.label_currentLocation);
            this.Controls.Add(this.panel_tagsList);
            this.Controls.Add(this.panel_filesList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textbox_search);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.textbox_search_container);
            this.Controls.Add(this.textbox_search_wrapper);
            this.Controls.Add(this.current_location_container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FileManager";
            this.Text = "File Manager";
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox textbox_search;
        private System.Windows.Forms.FlowLayoutPanel panel_tagsList;
        private System.Windows.Forms.Label label_currentLocation;
        private System.Windows.Forms.Button textbox_search_wrapper;
        private System.Windows.Forms.Button textbox_search_container;
        private System.Windows.Forms.Button current_location_container;
    }
}

