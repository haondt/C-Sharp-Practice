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

namespace Replicator
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private bool noSpaces = true;
        private bool validInput = false;
        private bool validOutput = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ;
        }

        // Checkbox for keeping or replacing spaces
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // update global variable based on check value
            noSpaces = checkBox1.Checked;
            // Verify that the output folder follows the constraint
            error_messages();
        }



        // Button to browse for input folder
        private void button1_Click(object sender, EventArgs e)
        {
            // Browse for folder
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Update box
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        
        // Button to browse for output folder
        private void button2_Click(object sender, EventArgs e)
        {
            // Browse for folder
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Update box
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // Input folder has been updated
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Verify that folder exists
            validInput = Directory.Exists(textBox1.Text);
            // update error message
            error_messages();
        }

        // Output folder has been updated
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Verify that folder exists
            validOutput = Directory.Exists(textBox2.Text);
            // update error message
            error_messages();
        }


        

        // Build button is pressed
        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "built";
        }

        // Event concerning error message has passed
        private void error_messages()
        {
            // check that spaces arent in output if not allowed
            if (noSpaces && textBox2.Text.Contains(" "))
            {
                validOutput = false;
            }
            // Otherwise, recompare against existent directory
            else
            {
                validOutput = Directory.Exists(textBox2.Text);
            }
            // check that input and output names are valid
            button3.Enabled = validInput && validOutput;
            if (validOutput)
            {
                button3.Enabled = IsDirectoryEmpty(textBox2.Text);
            }
            // Build error message
            string errorMessage = "";
            if (!validInput && textBox1.Text != "")
            {
                errorMessage += "Input folder name is invalid or doesn't exist.\n";
            }
            if (!validOutput && textBox2.Text != "")
            {
                errorMessage += "Output folder name is invalid or doesn't exist.\n";
            }
            if (validOutput)
            {
                if (!IsDirectoryEmpty(textBox2.Text))
                {
                    errorMessage += "Output directory must be empty.\n";
                }
            }

            label4.Text = errorMessage;
        }

        // Checks if a directory is empty
        // via Thomas Levesque https://stackoverflow.com/a/954837
        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

    }
}
