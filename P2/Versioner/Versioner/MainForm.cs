
/* ------------------------------------------------------------------------------------------------
 * 
 * Name: MainForm.cs
 * 
 * Author: Noah Burghardt
 * 
 * Company: University of Alberta
 * 
 * Description: Provides methods to respond to and change form view.
 * 
 * ------------------------------------------------------------------------------------------------
 */
namespace Versioner
{
    #region Namespaces

    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// Class containing form methods
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        private Versioner versioner;
        // seperate project list to avoid making versioner list readonly
        private List<string> projectList = new List<string>();
        private string directory, extension;
        private bool goodFile = false;
        private bool goodProject = false;
        private bool goodName = false;
        private bool goodVersion = false;

        #endregion

        #region Public Methods

        /// <summary>
        /// Initialization of form.
        /// </summary>
        /// <param name="versioner">Versioner object to manage database file.</param>
        public MainForm(Versioner versioner)
        {
            InitializeComponent();
            MaximizeBox = false;
            this.versioner = versioner;
            this.projectList.AddRange(versioner.GetProjects());
            ProjectComboBox.DataSource = projectList;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Input file browsing button press.
        /// </summary>
        private void InputBrowseButton_Click(object sender, EventArgs e)
        {
            // Browse for input file
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // update box
                InputFileTextBox.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Text changed in input file
        /// </summary>
        private void InputFileTextBox_TextChanged(object sender, EventArgs e)
        {
            // Ensure file exists
            if (File.Exists(InputFileTextBox.Text))
            {
                this.goodFile = true;
                this.directory = Path.GetDirectoryName(InputFileTextBox.Text);
                this.extension = Path.GetExtension(InputFileTextBox.Text);
                // Attempt to parse input file
                // Check to see if the filename matches expected format
                if (Regex.IsMatch(InputFileTextBox.Text, @"^.*\\[a-zA-Z0-9-\.]+_[a-zA-Z0-9-\.]+_[a-zA-Z0-9-\.]+_[a-zA-Z0-9-\.]+\..*$"))
                {
                    // Parse values and populate boxes
                    string name = Path.GetFileName(InputFileTextBox.Text);
                    string[] fileParts = name.Split('_');

                    // Populate fields
                    ProjectComboBox.Text = fileParts[0];
                    FileNameTextBox.Text = fileParts[1];
                    VersionTextBox.Text = fileParts[2];

                    // Attempt to parse date
                    try
                    {
                        dateTimePicker.Value = DateTime.Parse(fileParts[3].Split('.')[0]);
                    }
                    catch(FormatException)
                    {
                        // If date format is unrecognizable, just use todays date
                        dateTimePicker.Value = DateTime.Today;
                        ErrorMessageLabel.Text = "Unrecognized date format";
                    }
                }
                // If unparseable, just insert the filename and blank out the other fields
                else
                {
                    FileNameTextBox.Text = Path.GetFileNameWithoutExtension(InputFileTextBox.Text);
                    ProjectComboBox.Text = "";
                    VersionTextBox.Text = "";
                    dateTimePicker.Value = DateTime.Today;
                    Error_check();
                }
            }
            // Empty box is not submittable but doesn't show an error
            else if(InputFileTextBox.Text == "")
            {
                this.goodFile = false;
                Error_check();
            }
            else
            {
                this.goodFile = false;
                Error_check();
                ErrorMessageLabel.Text = "Input File not found.";
            }
        }

        /// <summary>
        /// Change detected in Project box.
        /// </summary>
        private void ProjectComboBox_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(ProjectComboBox.Text, @"^[a-zA-Z0-9-\.]+$"))
            {
                goodProject = false;
                ProjectComboBox.ForeColor = Color.DarkRed;
            }
            else
            {
                goodProject = true;
                ProjectComboBox.ForeColor = Color.Black;
            }
            Error_check();
        }
        
        /// <summary>
        /// Change detected in file name box.
        /// </summary>
        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(FileNameTextBox.Text, @"^[a-zA-Z0-9-\.]+$"))
            {
                goodName = false;
                FileNameTextBox.ForeColor = Color.DarkRed;
            }
            else
            {
                goodName = true;
                FileNameTextBox.ForeColor = Color.Black;
            }
            Error_check();
        }
        
        /// <summary>
        /// Change detected in version number box.
        /// </summary>
        private void VersionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(VersionTextBox.Text, @"^[a-zA-Z0-9-\.]+$"))
            {
                goodVersion = false;
                VersionTextBox.ForeColor = Color.DarkRed;
            }
            else
            {
                goodVersion = true;
                VersionTextBox.ForeColor = Color.Black;
            }
            Error_check();
        }

        /// <summary>
        /// Date Change.
        /// </summary>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Rebuild output file name
            Error_check();
        }

        /// <summary>
        /// Save button is clicked.
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(OutputFileTextBox.Text))
            {
                ErrorMessageLabel.Text = "Output file already exists.";
            }
            if (versioner.AddProject(ProjectComboBox.Text))
            {
                try
                {
                    // Move file
                    File.Move(InputFileTextBox.Text, OutputFileTextBox.Text);
                    // Refresh drop down data
                    this.projectList = new List<string>();
                    this.projectList.AddRange(versioner.GetProjects());
                    ProjectComboBox.DataSource = this.projectList;

                    // Disable button, since old file now no longer exists
                    this.goodFile = false;
                    SaveButton.Enabled = false;
                    ErrorMessageLabel.Text = "File moved!";
                }
                // Catch all exceptions
                catch (Exception)
                {
                    ErrorMessageLabel.Text = "Error in saving file";
                }
            }
            else
            {
                ErrorMessageLabel.Text = "Error in adding project.";
            }
        }

        /// <summary>
        /// Checks to verify all conditions are good and updates output preview.
        /// </summary>
        private void Error_check()
        {
            SaveButton.Enabled = goodFile && goodName && goodProject && goodVersion;
            if (SaveButton.Enabled)
            {
                OutputFileTextBox.Text = this.directory + '\\' +
                ProjectComboBox.Text[0].ToString().ToUpper() + ProjectComboBox.Text.Substring(1).ToLower() + '_' +
                FileNameTextBox.Text + '_' +
                VersionTextBox.Text + '_' +
                dateTimePicker.Value.ToShortDateString().Replace('/', '-')  +
                this.extension;
            }
            else
            {
                OutputFileTextBox.Text = "";
            }
            ErrorMessageLabel.Text = "";
        }

        #endregion
    }
}
