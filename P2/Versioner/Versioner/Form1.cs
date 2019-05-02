using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Versioner
{
    public partial class Form1 : Form
    {
        private Versioner versioner;
        // seperate project list to avoid making versioner list readonly
        private List<string> projectList = new List<string>();
        private string directory, extension;
        private bool goodFile = false;
        private bool goodProject = false;
        private bool goodName = false;
        private bool goodVersion = false;

        // Initialization
        public Form1(Versioner versioner)
        {
            InitializeComponent();
            MaximizeBox = false;
            this.versioner = versioner;
            this.projectList.AddRange(versioner.getProjects());
            comboBox1.DataSource = projectList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Input file browsing button press
        private void button1_Click(object sender, EventArgs e)
        {
            // Browse for input file
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // update box
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        // Text changed in input file
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Ensure file exists
            if (File.Exists(textBox1.Text))
            {
                this.goodFile = true;
                this.directory = Path.GetDirectoryName(textBox1.Text);
                this.extension = Path.GetExtension(textBox1.Text);
                // Attempt to parse input file
                // Check to see if the filename matches expected format
                if (Regex.IsMatch(textBox1.Text, @"^.*\\[a-zA-Z0-9-\.]+_[a-zA-Z0-9-\.]+_[a-zA-Z0-9-\.]+_[a-zA-Z0-9-\.]+\..*$"))
                {
                    // Parse values and populate boxes
                    string name = Path.GetFileName(textBox1.Text);
                    string[] fileParts = name.Split('_');

                    // Populate fields
                    comboBox1.Text = fileParts[0];
                    textBox4.Text = fileParts[1];
                    textBox5.Text = fileParts[2];

                    // Attempt to parse date
                    try
                    {
                        dateTimePicker1.Value = DateTime.Parse(fileParts[3].Split('.')[0]);
                    }
                    catch(FormatException)
                    {
                        // If date format is unrecognizable, just use todays date
                        dateTimePicker1.Value = DateTime.Today;
                        label6.Text = "Unrecognized date format";
                    }
                }
                // If unparseable, just insert the filename and blank out the other fields
                else
                {
                    textBox4.Text = Path.GetFileNameWithoutExtension(textBox1.Text);
                    comboBox1.Text = "";
                    textBox5.Text = "";
                    dateTimePicker1.Value = DateTime.Today;
                    error_check();
                }
            }
            // Empty box is not submittable but doesn't show an error
            else if(textBox1.Text == "")
            {
                this.goodFile = false;
                error_check();
            }
            else
            {
                this.goodFile = false;
                error_check();
                label6.Text = "Input File not found.";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ;
        }

        // Change detected in Project box
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(comboBox1.Text, @"^[a-zA-Z0-9-\.]+$"))
            {
                goodProject = false;
                comboBox1.ForeColor = Color.DarkRed;
            }
            else
            {
                goodProject = true;
                comboBox1.ForeColor = Color.Black;
            }
            error_check();
        }

        // Change detected in file name box
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox4.Text, @"^[a-zA-Z0-9-\.]+$"))
            {
                goodName = false;
                textBox4.ForeColor = Color.DarkRed;
            }
            else
            {
                goodName = true;
                textBox4.ForeColor = Color.Black;
            }
            error_check();
        }

        // Change detected in version number box
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox5.Text, @"^[a-zA-Z0-9-\.]+$"))
            {
                goodVersion = false;
                textBox5.ForeColor = Color.DarkRed;
            }
            else
            {
                goodVersion = true;
                textBox5.ForeColor = Color.Black;
            }
            error_check();
        }

        // Date Change
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Rebuild output file name
            error_check();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox6.Text))
            {
                label6.Text = "Output file already exists.";
            }
            if (versioner.AddProject(comboBox1.Text))
            {
                try
                {
                    // Move file
                    File.Move(textBox1.Text, textBox6.Text);
                    // Disable button, since old file now no longer exists
                    this.goodFile = false;
                    button2.Enabled = false;
                    label6.Text = "File moved!";
                }
                // Catch all exceptions
                catch (Exception)
                {
                    label6.Text = "Error in saving file";
                }
            }
            else
            {
                label6.Text = "Error in adding project.";
            }
        }

        // Checks to verify all conditions are good and updates output preview
        private void error_check()
        {
            button2.Enabled = goodFile && goodName && goodProject && goodVersion;
            if (button2.Enabled)
            {
                textBox6.Text = this.directory + '\\' +
                comboBox1.Text[0].ToString().ToUpper() + comboBox1.Text.Substring(1).ToLower() + '_' +
                textBox4.Text + '_' +
                textBox5.Text + '_' +
                dateTimePicker1.Value.ToShortDateString().Replace('/', '-')  +
                this.extension;
            }
            else
            {
                textBox6.Text = "";
            }
            label6.Text = "";
        }
    }
}
