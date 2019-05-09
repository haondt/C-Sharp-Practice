using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LINQApp
{
    class CommentSearcher
    {
        public String JsonFilePath { get; set; }
        private JObject comments; 
        /// <summary>
        /// Loads in the json data provided from .JsonFilePath
        /// </summary>
        public void LoadJson()
        {

            // Load json data into memory
            // Data supplied from http://files.pushshift.io/reddit/comments/
            String JsonFilePath = "C:\\Users\\Noah\\Documents\\C-Sharp-Practice\\LINQ\\reddit_comments.json";
            String json = "";
            using (StreamReader r = new StreamReader(JsonFilePath))
            {
                json = r.ReadToEnd();
            }

            // save comments as json object
            this.comments = JObject.Parse(json);
        }

        /// <summary>
        /// Gets the number of comments in the json object
        /// </summary>
        /// <returns>Integer number of comments</returns>
        public int getNumComments()
        {
            var authors = from c in comments["comments"]
                          select c;
            return authors.Count();
        }

        /// <summary>
        /// Fetches categories of comment data (score, gilded, is_op etc)
        /// </summary>
        /// <returns>IList<> object of category strings</returns>
        public IList<String> getDataCategories()
        {
            return ((JObject)this.comments["comments"][0]).Properties().Select(p => p.Name).ToList();
        }

        /// <summary>
        /// Finds comments containing the given substring (including as part of a word).
        /// Using query syntax.
        /// </summary>
        /// <param name="term">The substring to search for</param>
        /// <returns>IEnumerable<> of comment body strings</returns>
        public IEnumerable<String> stringSearch(String term)
        {
            return from c in this.comments["comments"]
                   where ((String) c["body"]).Contains(term)
                   select (String) c["body"];
        }

        // TODO: finds the most controversial comment
        public String controversialComment()
        {
            return "";
        }

        /// <summary>
        /// Finds comments from the given subreddit, using method syntax.
        /// </summary>
        /// <param name="subreddit">Subreddit to get results from. Capitalization is important.</param>
        /// <returns>IEnumerable of comment body strings</returns>
        public IEnumerable<String> fromSub(String subreddit)
        {
            return this.comments["comments"]
                .Where(c => ((String) c["subreddit"]) == subreddit)
                .Select(c => (String) c["body"]);
        }

        /// <summary>
        /// Returns number of short comments (under 20 characters), using lambda function assigned to
        /// Func delegate.
        /// </summary>
        /// <returns>Integer number of short comments</returns>
        public int getNumShortComments()
        {
            // Create lambda functions
            Func<JToken, String> commentBody = c => ((String)c["body"]);
            Func<JToken, bool> isShort = c => (commentBody(c)).Length <= 20;

            // Parse data
            IEnumerable<String> shortComments =  
                this.comments["comments"]
                .Where(isShort)
                .Select(commentBody);

            // return result
            return shortComments.Count();
        }

        /// <summary>
        /// Returns number of long comments (over 1000 characters), using lambda function assigned to
        /// Action delegate.
        /// </summary>
        /// <returns>Integer number of long comments</returns>
        public int getNumLongComments()
        {
            int counter = 0;
            Action<JToken> checkLong = c =>
            {
                if (((String)c["body"]).Length >= 1000)
                    counter++;
            };

            foreach (JToken c in this.comments["comments"])
                checkLong(c);

            return counter;
        }

        /// <summary>
        /// Returns the ith comment.
        /// </summary>
        /// <param name="i">Index of comment to return</param>
        /// <returns>Comment body string</returns>
        public String index(int i)
        {
            JToken comment = this.comments["comments"]
                .Where((c, ci) => ci == i)
                .First();
            return (String)comment["body"];
        }



    }
}
