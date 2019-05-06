namespace Versioner
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using System.Text.RegularExpressions;

    static class Program
    {
        static Versioner versioner;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Ensure db location exists  
            string db_location = Application.StartupPath + "\\VersionerProjects.txt";
            try
            {
                // Open file
                FileStream fp = File.Open(db_location, FileMode.OpenOrCreate);
                fp.Close();
                // Create versioner
                versioner = new Versioner(db_location);


                // run UI
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(versioner));
            }
            // Indicate that the file couldn't be found
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Unable to find db file.");
            }
        }
    }
    public class Versioner
    {
        private string db_location;
        private FileStream fp;
        private List<string> projects = new List<string>();

        // Constructor, assumes that db_location is an existing file
        public Versioner(string db_location)
        {
            // set db_location and pull data
            this.db_location = db_location;
            this.readProjects();
        }

        // Get project list from file and store internally
        public void readProjects()
        {
            // Open file
            this.fp = File.Open(this.db_location, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fp);
            string line = "";
            // Read contents
            while((line = reader.ReadLine()) != null)
            {
                // Add contents to project list
                this.projects.Add(line);
            }
            this.fp.Close();
        }

        public List<string> getProjects()
        {
            return this.projects;
        }

        public bool AddProject(string project)
        {
            // Ensure name is valid
            if (!string.IsNullOrEmpty(project))
            {
                // Ensure name is alphanumeric
                if (Regex.IsMatch(project, @"^[a-zA-Z0-9-\.]+$"))
                {
                    // clean the captilization of the project
                    project = project[0].ToString().ToUpper() + project.Substring(1).ToLower();

                    // check if project is already in project list
                    if (!this.projects.Contains(project))
                    {
                        // Add project to project list
                        this.projects.Add(project);
                        // Add project to file
                        using (StreamWriter writer = new StreamWriter(db_location, true))
                        {
                            writer.WriteLine(project);
                        }
                    }
                    return true;
                }
            }
            return false;
        }


        
            
    }
}
