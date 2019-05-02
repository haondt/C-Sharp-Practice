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

namespace Versioner
{
    public partial class Form1 : Form
    {
        // Initialization
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
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

            }
            else
            {
                label6.Text = "Input File not found.";
            }
        }
    }
}
