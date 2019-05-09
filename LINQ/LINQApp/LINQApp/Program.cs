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
                Console.WriteLine("\t" + cat);
            }

            // Search for the number of comments containing a particular term
            String term = "egg";
            Console.WriteLine("There are {0} comments containing the term \"{1}\"",
                cs.stringSearch(term).Count(),
                term);

            // Search for the number of comments from a particular subreddit
            String sub = "AskReddit";
            Console.WriteLine("{0}% of comments come from the {1} subreddit.", 
                ((float) cs.fromSub(sub).Count() / cs.getNumComments())*100, sub);

            // Search for short comments
            Console.WriteLine("There are {0} short comments.", cs.getNumShortComments());

            // Search for long comments
            Console.WriteLine("There are {0} long comments.", cs.getNumLongComments());

            // Search for the nth comment
            int index = 10000;
            Console.WriteLine("Comment #{0} reads:\n{1}", index, cs.index(index));
            
            // wait for user input
            Console.ReadKey();
        }
    }
}
