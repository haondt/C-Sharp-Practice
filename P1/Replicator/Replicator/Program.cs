using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Replicator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    // Recursively reads folders from input folder and creates matching ones in output folder
    public class FolderBuilder
    {
        private string inPath = "";
        private string outPath = "";
        private bool noSpaces = true;

        public void setInPath(string path)
        {
            this.inPath = path;
        }

        public void setOutPath(string path)
        {
            this.outPath = path;
        }

        public void setNoSpaces(bool noSpaces)
        {
            this.noSpaces = noSpaces;
        }

        public bool Build()
        {
            // Perform sanity checks
            if(Directory.Exists(this.inPath) && Directory.Exists(this.outPath) && this.inPath != this.outPath)
            {
                if (Form1.IsDirectoryEmpty(this.outPath)){
                    // Replicate folder structure
                    return recursiveBuild(this.inPath, this.outPath);
                }

            }
            return false;

        }

        // Copies directories from inPath to outPath
        private bool recursiveBuild(string inPath, string outPath)
        {
            // Depth first search
            string outSubDir = "";
            // Simply return false for inaccessible (due to permissions) directories
            try
            {
                foreach (string inSubDir in Directory.GetDirectories(inPath))
                {
                    // Generate new directory location
                    // Replace spaces with hyphens if requested
                    if (this.noSpaces)
                    {
                        outSubDir = this.outPath + inSubDir.Substring(this.inPath.Length).Replace(" ", "-");
                    }
                    else
                    {
                        outSubDir = this.outPath + inSubDir.Substring(this.inPath.Length);
                    }

                    /* If the top-level output directory is inside the input directory, 
                     * Copy the directory but not its contents.
                     */
                    if (inSubDir == this.outPath)
                    {
                        // Attempt to build directory
                        try
                        {
                            Directory.CreateDirectory(outSubDir);
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // Attempt to build directory
                        try
                        {
                            Directory.CreateDirectory(outSubDir);
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                        // Build subdirectories
                        if (!recursiveBuild(inSubDir, outSubDir))
                        {
                            return false;
                        }
                    }
                }
            }
            // Omit Directories without read/write access
            catch (UnauthorizedAccessException)
            {
                // Delete the affected directory
                if (Directory.Exists(outPath))
                {
                    Directory.Delete(outPath);
                }
                return true;
            }
            return true;
        }
    }
}
