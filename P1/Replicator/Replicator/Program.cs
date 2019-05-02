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
            if(Directory.Exists(this.inPath) && Directory.Exists(this.outPath))
            {
                if (Form1.IsDirectoryEmpty(this.outPath)){
                    // Depth first search
                    string outSubDir = "";
                    foreach (string inSubDir in Directory.GetDirectories(this.inPath))
                    {
                        // Generate new directory location
                        outSubDir = this.outPath + inSubDir.Substring(this.inPath.Length);
                        // Replace spaces with hyphens if requested
                        if (this.noSpaces)
                        {
                            outSubDir = outSubDir.Replace(" ", "-");
                        }
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
                    return true;
                }

            }
            return false;

        }

        // Copies directories from inPath to outPath
        private void recursiveBuild(string inPath, string outPath)
        {
            foreach(string subDir in Directory.GetDirectories(inPath))
            {
                /* If the top-level output directory is inside the input directory, 
                 * Copy the directory but not its contents.
                 */
                if(subDir == this.outPath)
                {
                    ;
                }
            }
        }
    }
}
