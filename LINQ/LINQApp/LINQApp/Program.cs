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
            String sub = "AskOuija";
            Console.WriteLine("{0}% of comments come from the {1} subreddit.", 
                ((float) cs.fromSub(sub).Count() / cs.getNumComments())*100, sub);

            // Search for short comments
            Console.WriteLine("There are {0} short comments.", cs.getNumShortComments());

            // Search for long comments
            Console.WriteLine("There are {0} long comments.", cs.getNumLongComments());

            // Line break
            Console.WriteLine("");

            // Search for the nth comment
            int index = 301;
            Console.WriteLine("Comment #{0} reads:\n{1}\n", index, cs.index(index));

            // Search for the most controversial comment
            Console.WriteLine("The most controversial comment reads:\n{0}\n", cs.controversialComment());

            // Search for the comment that mentions a term the most
            term = "salt";
            Console.WriteLine("The comment that mentions \"{0}\" the most reads:\n{1}\n",
                term, cs.mentions(term));
            // Search for the best comment from the most recent 24 hours
            Console.WriteLine("The best most recent comment reads:\n{0}\n", cs.bestRecent());

            // Search for the most popular subreddit
            Console.WriteLine("The most popular subreddit is {0}, with {1}% of the comments.",
                cs.mostActiveSub(),
                ((float)cs.fromSub(cs.mostActiveSub()).Count() / cs.getNumComments()) * 100);

            // Check if any comments are gilded
            Console.WriteLine("The data {0} gilded comments.", 
                cs.anyGold() ? "contains" : "does not contain");

            // Check if any comments come from a particular subreddit
            sub = "Overwatch";
            Console.WriteLine("The data {0} comments from r/{1}.",
                cs.anyFromSub(sub) ? "contains" : "does not contain",
                sub);

            // wait for user input
            Console.ReadKey();
        }
    }
}
