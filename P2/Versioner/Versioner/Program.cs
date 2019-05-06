/* ------------------------------------------------------------------------------------------------
 * 
 * Name: Program.cs
 * 
 * Author: Noah Burghardt
 * 
 * Company: University of Alberta
 * 
 * Description: Classes to begin execution of program and to handle modification of database file.
 * 
 * ------------------------------------------------------------------------------------------------
 */

namespace Versioner
{
    #region Namespaces

    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.IO;
    using System.Text.RegularExpressions;

    #endregion

    /// <summary>
    /// Class containing entry point for program.
    /// </summary>
    static class Program
    {
        #region Fields

        static Versioner versioner;

        #endregion

        #region Public Methods

        /// <summary>
        /// The main entry point for the application. 
        /// Also creates db file if it doesn't exist already.
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
                Application.Run(new MainForm(versioner));
            }
            // Indicate that the file couldn't be found
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Unable to find db file.");
            }
        }

        #endregion

    }

    /// <summary>
    /// Provides a set of methods for interacting with database file. 
    /// </summary>
    public class Versioner
    {
        #region Fields

        private string Db_location;
        private FileStream fp;
        private List<string> projects = new List<string>();

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Constructor, assumes that Db_location is an existing file.
        /// Only one should be instantiated to prevent concurrency issues.
        /// </summary>
        /// <param name="db_location">The path to the database (plaintext) file.</param>
        public Versioner(string db_location)
        {
            // set Db_location and pull data
            this.Db_location = db_location;
            this.readProjects();
        }

        /// <summary>
        /// Get project list from file and store internally
        /// </summary>
        public void readProjects()
        {
            // Open file
            this.fp = File.Open(this.Db_location, FileMode.OpenOrCreate);
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
        /// <summary>
        /// Fetch internal copy of project names.
        /// </summary>
        /// <returns>List of project names</returns>
        public List<string> getProjects()
        {
            return this.projects;
        }

        /// <summary>
        /// Adds a project name to internal list and to database file.
        /// Standardizes casing of project name before adding to file.
        /// </summary>
        /// <param name="project">Name of project to add.</param>
        /// <returns>True if project was added successfully,
        /// false if project contains illegal characters or is an empty string.</returns>
        /// <remarks>Method will return true if the project name is already in the list but
        /// will not create a duplicate entry.</remarks>
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
                        using (StreamWriter writer = new StreamWriter(Db_location, true))
                        {
                            writer.WriteLine(project);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
