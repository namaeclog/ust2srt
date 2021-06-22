
namespace ust2srt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openfile_dialog = new System.Windows.Forms.OpenFileDialog();
            this.load_ust = new System.Windows.Forms.Button();
            this.label_selected_filename = new System.Windows.Forms.Label();
            this.edit_area = new System.Windows.Forms.TextBox();
            this.checkbox_inludes_oto = new System.Windows.Forms.CheckBox();
            this.button_export_srt = new System.Windows.Forms.Button();
            this.locate_voice_dir = new System.Windows.Forms.Button();
            this.locate_vb_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tooltip_vb_location = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.left_symbol_text = new System.Windows.Forms.TextBox();
            this.right_symbol_text = new System.Windows.Forms.TextBox();
            this.max_R = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tooltip_max_R = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.checkbox_remove_overlap = new System.Windows.Forms.CheckBox();
            this.checkbox_all_prefix = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.max_R)).BeginInit();
            this.SuspendLayout();
            // 
            // openfile_dialog
            // 
            this.openfile_dialog.FileName = "*.ust";
            this.openfile_dialog.Filter = "ust project|*.ust|plain text|*.txt";
            this.openfile_dialog.SupportMultiDottedExtensions = true;
            this.openfile_dialog.Title = "Select ust...";
            // 
            // load_ust
            // 
            this.load_ust.Location = new System.Drawing.Point(12, 12);
            this.load_ust.Name = "load_ust";
            this.load_ust.Size = new System.Drawing.Size(132, 29);
            this.load_ust.TabIndex = 0;
            this.load_ust.Text = "Load ust file";
            this.load_ust.UseVisualStyleBackColor = true;
            this.load_ust.Click += new System.EventHandler(this.load_ust_Click);
            // 
            // label_selected_filename
            // 
            this.label_selected_filename.AutoSize = true;
            this.label_selected_filename.Location = new System.Drawing.Point(148, 17);
            this.label_selected_filename.Name = "label_selected_filename";
            this.label_selected_filename.Size = new System.Drawing.Size(138, 19);
            this.label_selected_filename.TabIndex = 1;
            this.label_selected_filename.Text = "no file selected yet";
            // 
            // edit_area
            // 
            this.edit_area.AcceptsReturn = true;
            this.edit_area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edit_area.Enabled = false;
            this.edit_area.Location = new System.Drawing.Point(10, 162);
            this.edit_area.Multiline = true;
            this.edit_area.Name = "edit_area";
            this.edit_area.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edit_area.ShortcutsEnabled = false;
            this.edit_area.Size = new System.Drawing.Size(860, 579);
            this.edit_area.TabIndex = 2;
            this.edit_area.Click += new System.EventHandler(this.edit_area_Click);
            this.edit_area.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edit_area_KeyDown);
            this.edit_area.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edit_area_KeyPress);
            this.edit_area.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edit_area_KeyUp);
            // 
            // checkbox_inludes_oto
            // 
            this.checkbox_inludes_oto.AutoSize = true;
            this.checkbox_inludes_oto.Enabled = false;
            this.checkbox_inludes_oto.Location = new System.Drawing.Point(10, 47);
            this.checkbox_inludes_oto.Name = "checkbox_inludes_oto";
            this.checkbox_inludes_oto.Size = new System.Drawing.Size(181, 23);
            this.checkbox_inludes_oto.TabIndex = 5;
            this.checkbox_inludes_oto.Text = "includes preutterance";
            this.tooltip_vb_location.SetToolTip(this.checkbox_inludes_oto, "you MUST locate UTAU \"voice\" folder before using \"includes preuttrance\" to export" +
        "");
            this.checkbox_inludes_oto.UseVisualStyleBackColor = true;
            this.checkbox_inludes_oto.CheckedChanged += new System.EventHandler(this.checkbox_inludes_oto_CheckedChanged);
            // 
            // button_export_srt
            // 
            this.button_export_srt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_export_srt.Enabled = false;
            this.button_export_srt.Location = new System.Drawing.Point(776, 12);
            this.button_export_srt.Name = "button_export_srt";
            this.button_export_srt.Size = new System.Drawing.Size(94, 29);
            this.button_export_srt.TabIndex = 6;
            this.button_export_srt.Text = "Export srt";
            this.button_export_srt.UseVisualStyleBackColor = true;
            this.button_export_srt.Click += new System.EventHandler(this.export_to_srt);
            // 
            // locate_voice_dir
            // 
            this.locate_voice_dir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.locate_voice_dir.Location = new System.Drawing.Point(652, 126);
            this.locate_voice_dir.Name = "locate_voice_dir";
            this.locate_voice_dir.Size = new System.Drawing.Size(218, 29);
            this.locate_voice_dir.TabIndex = 7;
            this.locate_voice_dir.Text = "Locate UTAU\\voice manually";
            this.tooltip_vb_location.SetToolTip(this.locate_voice_dir, Program.VOICEPATH);
            this.locate_voice_dir.UseVisualStyleBackColor = true;
            this.locate_voice_dir.Click += new System.EventHandler(this.locate_voice_dir_Click);
            // 
            // locate_vb_dialog
            // 
            this.locate_vb_dialog.Description = "Locate UTAU voice Path...";
            this.locate_vb_dialog.ShowNewFolderButton = false;
            this.locate_vb_dialog.UseDescriptionForTitle = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "left symbol";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(772, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "right symbol";
            // 
            // left_symbol_text
            // 
            this.left_symbol_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.left_symbol_text.Location = new System.Drawing.Point(684, 74);
            this.left_symbol_text.Name = "left_symbol_text";
            this.left_symbol_text.Size = new System.Drawing.Size(86, 27);
            this.left_symbol_text.TabIndex = 10;
            this.left_symbol_text.Text = "[";
            // 
            // right_symbol_text
            // 
            this.right_symbol_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.right_symbol_text.Location = new System.Drawing.Point(776, 74);
            this.right_symbol_text.Name = "right_symbol_text";
            this.right_symbol_text.Size = new System.Drawing.Size(94, 27);
            this.right_symbol_text.TabIndex = 11;
            this.right_symbol_text.Text = "]";
            // 
            // max_R
            // 
            this.max_R.Enabled = false;
            this.max_R.Location = new System.Drawing.Point(68, 129);
            this.max_R.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.max_R.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.max_R.Name = "max_R";
            this.max_R.Size = new System.Drawing.Size(72, 27);
            this.max_R.TabIndex = 12;
            this.tooltip_max_R.SetToolTip(this.max_R, "-1: unlimited\r\n0: don\'t export R\r\n>=1: the maximum count of each R section");
            this.max_R.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "max R";
            // 
            // tooltip_max_R
            // 
            this.tooltip_max_R.ToolTipTitle = "Set the maximum R in each R section";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(676, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkbox_remove_overlap
            // 
            this.checkbox_remove_overlap.AutoSize = true;
            this.checkbox_remove_overlap.Enabled = false;
            this.checkbox_remove_overlap.Location = new System.Drawing.Point(10, 76);
            this.checkbox_remove_overlap.Name = "checkbox_remove_overlap";
            this.checkbox_remove_overlap.Size = new System.Drawing.Size(180, 23);
            this.checkbox_remove_overlap.TabIndex = 15;
            this.checkbox_remove_overlap.Text = "remove overlap of srt";
            this.checkbox_remove_overlap.UseVisualStyleBackColor = true;
            // 
            // checkbox_all_prefix
            // 
            this.checkbox_all_prefix.AutoSize = true;
            this.checkbox_all_prefix.Enabled = false;
            this.checkbox_all_prefix.Location = new System.Drawing.Point(10, 105);
            this.checkbox_all_prefix.Name = "checkbox_all_prefix";
            this.checkbox_all_prefix.Size = new System.Drawing.Size(203, 23);
            this.checkbox_all_prefix.TabIndex = 16;
            this.checkbox_all_prefix.Text = "show all prefix and suffix";
            this.checkbox_all_prefix.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 753);
            this.Controls.Add(this.checkbox_all_prefix);
            this.Controls.Add(this.checkbox_remove_overlap);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.max_R);
            this.Controls.Add(this.right_symbol_text);
            this.Controls.Add(this.left_symbol_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.locate_voice_dir);
            this.Controls.Add(this.button_export_srt);
            this.Controls.Add(this.checkbox_inludes_oto);
            this.Controls.Add(this.edit_area);
            this.Controls.Add(this.label_selected_filename);
            this.Controls.Add(this.load_ust);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ust2str";
            ((System.ComponentModel.ISupportInitialize)(this.max_R)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openfile_dialog;
        private System.Windows.Forms.Button load_ust;
        private System.Windows.Forms.Label label_selected_filename;
        private System.Windows.Forms.TextBox edit_area;
        private System.Windows.Forms.CheckBox checkbox_inludes_oto;
        private System.Windows.Forms.Button button_export_srt;
        private System.Windows.Forms.Button locate_voice_dir;
        private System.Windows.Forms.FolderBrowserDialog locate_vb_dialog;
        private System.Windows.Forms.ToolTip tooltip_vb_location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox left_symbol_text;
        private System.Windows.Forms.TextBox right_symbol_text;
        private System.Windows.Forms.NumericUpDown max_R;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip tooltip_max_R;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkbox_remove_overlap;
        private System.Windows.Forms.CheckBox checkbox_all_prefix;
    }
}

