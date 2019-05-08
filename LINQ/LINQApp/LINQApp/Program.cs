using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq; 

namespace LINQApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build comment searcher
            CommentSearcher cs = new CommentSearcher();
            // Provide json file
            cs.JsonFilePath = "C:\\Users\\Noah\\Documents\\C-Sharp-Practice\\LINQ\\reddit_comments.json";
            // Load json file
            cs.LoadJson();

            // print stats
            Console.WriteLine("Found " + cs.getNumComments().ToString() + " comments.");
            Console.WriteLine("Data for each comment includes: ");
            foreach (var cat in cs.getDataCategories())
            {
                Console.WriteLine(cat);
            }
            
            Console.WriteLine(cs.stringSearch("egg").Count());
            // wait for user input
            Console.ReadKey();
        }
    }
}
