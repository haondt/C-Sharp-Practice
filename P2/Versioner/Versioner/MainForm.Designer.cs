namespace Versioner
{
    partial class MainForm
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
            this.InputFileTextBox = new System.Windows.Forms.TextBox();
            this.InputBrowseButton = new System.Windows.Forms.Button();
            this.ProjectLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.OutputFileLabel = new System.Windows.Forms.Label();
            this.ErrorMessageLabel = new System.Windows.Forms.Label();
            this.InputFileLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.VersionTextBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.OutputFileTextBox = new System.Windows.Forms.TextBox();
            this.Divider = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProjectComboBox = new System.Windows.Forms.ComboBox();
            this.HelpTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputFileTextBox
            // 
            this.InputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFileTextBox.Location = new System.Drawing.Point(103, 14);
            this.InputFileTextBox.Name = "InputFileTextBox";
            this.InputFileTextBox.Size = new System.Drawing.Size(488, 20);
            this.InputFileTextBox.TabIndex = 0;
            this.InputFileTextBox.TextChanged += new System.EventHandler(this.InputFileTextBox_TextChanged);
            // 
            // InputBrowseButton
            // 
            this.InputBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InputBrowseButton.Location = new System.Drawing.Point(597, 12);
            this.InputBrowseButton.Name = "InputBrowseButton";
            this.InputBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.InputBrowseButton.TabIndex = 1;
            this.InputBrowseButton.Text = "Browse...";
            this.InputBrowseButton.UseVisualStyleBackColor = true;
            this.InputBrowseButton.Click += new System.EventHandler(this.InputBrowseButton_Click);
            // 
            // ProjectLabel
            // 
            this.ProjectLabel.AutoSize = true;
            this.ProjectLabel.Location = new System.Drawing.Point(12, 43);
            this.ProjectLabel.Name = "ProjectLabel";
            this.ProjectLabel.Size = new System.Drawing.Size(43, 13);
            this.ProjectLabel.TabIndex = 2;
            this.ProjectLabel.Text = "Project:";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(12, 69);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(57, 13);
            this.FileNameLabel.TabIndex = 3;
            this.FileNameLabel.Text = "File Name:";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(12, 95);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(45, 13);
            this.VersionLabel.TabIndex = 4;
            this.VersionLabel.Text = "Version:";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(12, 124);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(33, 13);
            this.DateLabel.TabIndex = 5;
            this.DateLabel.Text = "Date:";
            // 
            // OutputFileLabel
            // 
            this.OutputFileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OutputFileLabel.AutoSize = true;
            this.OutputFileLabel.Location = new System.Drawing.Point(12, 234);
            this.OutputFileLabel.Name = "OutputFileLabel";
            this.OutputFileLabel.Size = new System.Drawing.Size(61, 13);
            this.OutputFileLabel.TabIndex = 6;
            this.OutputFileLabel.Text = "Output File:";
            // 
            // ErrorMessageLabel
            // 
            this.ErrorMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ErrorMessageLabel.AutoSize = true;
            this.ErrorMessageLabel.Location = new System.Drawing.Point(12, 260);
            this.ErrorMessageLabel.Name = "ErrorMessageLabel";
            this.ErrorMessageLabel.Size = new System.Drawing.Size(74, 13);
            this.ErrorMessageLabel.TabIndex = 7;
            this.ErrorMessageLabel.Text = "Error message";
            // 
            // InputFileLabel
            // 
            this.InputFileLabel.AutoSize = true;
            this.InputFileLabel.Location = new System.Drawing.Point(12, 18);
            this.InputFileLabel.Name = "InputFileLabel";
            this.InputFileLabel.Size = new System.Drawing.Size(53, 13);
            this.InputFileLabel.TabIndex = 8;
            this.InputFileLabel.Text = "Input File:";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(597, 229);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameTextBox.Location = new System.Drawing.Point(103, 66);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(488, 20);
            this.FileNameTextBox.TabIndex = 12;
            this.FileNameTextBox.TextChanged += new System.EventHandler(this.FileNameTextBox_TextChanged);
            // 
            // VersionTextBox
            // 
            this.VersionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionTextBox.Location = new System.Drawing.Point(103, 92);
            this.VersionTextBox.Name = "VersionTextBox";
            this.VersionTextBox.Size = new System.Drawing.Size(488, 20);
            this.VersionTextBox.TabIndex = 13;
            this.VersionTextBox.TextChanged += new System.EventHandler(this.VersionTextBox_TextChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.Location = new System.Drawing.Point(103, 118);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(488, 20);
            this.dateTimePicker.TabIndex = 15;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // OutputFileTextBox
            // 
            this.OutputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFileTextBox.Enabled = false;
            this.OutputFileTextBox.Location = new System.Drawing.Point(103, 231);
            this.OutputFileTextBox.Name = "OutputFileTextBox";
            this.OutputFileTextBox.Size = new System.Drawing.Size(488, 20);
            this.OutputFileTextBox.TabIndex = 16;
            // 
            // Divider
            // 
            this.Divider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Divider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Divider.Location = new System.Drawing.Point(15, 215);
            this.Divider.Name = "Divider";
            this.Divider.Size = new System.Drawing.Size(653, 2);
            this.Divider.TabIndex = 17;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ProjectComboBox
            // 
            this.ProjectComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.ProjectComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ProjectComboBox.FormattingEnabled = true;
            this.ProjectComboBox.Location = new System.Drawing.Point(103, 40);
            this.ProjectComboBox.Name = "ProjectComboBox";
            this.ProjectComboBox.Size = new System.Drawing.Size(488, 21);
            this.ProjectComboBox.TabIndex = 18;
            this.ProjectComboBox.TextChanged += new System.EventHandler(this.ProjectComboBox_TextChanged);
            // 
            // HelpTextLabel
            // 
            this.HelpTextLabel.AutoSize = true;
            this.HelpTextLabel.Location = new System.Drawing.Point(12, 152);
            this.HelpTextLabel.Name = "HelpTextLabel";
            this.HelpTextLabel.Size = new System.Drawing.Size(336, 13);
            this.HelpTextLabel.TabIndex = 19;
            this.HelpTextLabel.Text = "Names may not contain Non-alphanumeric characters or underscores.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 295);
            this.Controls.Add(this.HelpTextLabel);
            this.Controls.Add(this.ProjectComboBox);
            this.Controls.Add(this.Divider);
            this.Controls.Add(this.OutputFileTextBox);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.VersionTextBox);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.InputFileLabel);
            this.Controls.Add(this.ErrorMessageLabel);
            this.Controls.Add(this.OutputFileLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.ProjectLabel);
            this.Controls.Add(this.InputBrowseButton);
            this.Controls.Add(this.InputFileTextBox);
            this.MinimumSize = new System.Drawing.Size(700, 291);
            this.Name = "MainForm";
            this.Text = "Versioner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputFileTextBox;
        private System.Windows.Forms.Button InputBrowseButton;
        private System.Windows.Forms.Label ProjectLabel;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label OutputFileLabel;
        private System.Windows.Forms.Label ErrorMessageLabel;
        private System.Windows.Forms.Label InputFileLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.TextBox VersionTextBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox OutputFileTextBox;
        private System.Windows.Forms.Label Divider;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox ProjectComboBox;
        private System.Windows.Forms.Label HelpTextLabel;
    }
}

