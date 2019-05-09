using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Returns the most controversial comment that hasn't been deleted or removed.
        /// </summary>
        /// <returns>Comment body string</returns>
        public String controversialComment()
        {
            return (String) this.comments["comments"]
                .OrderByDescending(c => (int) c["controversiality"])
                .Where(c => (String) c["body"] != "[deleted]")
                .Where(c => (String) c["body"] != "[removed]")
                .First()["body"];
        }

        /// <summary>
        /// Finds the comment with the most mentions of a particular term (including as a part of another term)
        /// </summary>
        /// <param name="term">The term to search for</param>
        /// <returns>The comment body string</returns>
        public String mentions(String term)
        {
            // Build lambda function for counting occurrences
            Func<JToken, int> wordscore = c =>
             {
                 String body = (String)c["body"];
                 return Regex.Matches(body.ToLower(), term.ToLower()).Count;
             };

            // Run search and take top result
            return (String)this.comments["comments"]
                .OrderByDescending(wordscore)
                .Where(c => wordscore(c) >= 1)
                .First()["body"];
        }

        /// <summary>
        /// Finds comments from the given subreddit, using method syntax.
        /// </summary>
        /// <param name="subreddit">Subreddit to get results from.</param>
        /// <returns>IEnumerable of comment body strings</returns>
        public IEnumerable<String> fromSub(String subreddit)
        {
            return this.comments["comments"]
                .Where(c => ((String) c["subreddit"]).ToLower() == subreddit.ToLower())
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
            // Set up counter
            int counter = 0;

            // Define lambda function for increasing counter
            Action<JToken> checkLong = c =>
            {
                if (((String)c["body"]).Length >= 1000)
                    counter++;
            };

            // Apply lambda function to each comment
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

        /// <summary>
        /// Finds the highest scoring comment from the most recent 24 hours
        /// </summary>
        /// <returns></returns>
        public String bestRecent()
        {
            // Define method to get utc rounded to day
            Func<JToken, long> timeStampDay = c =>
            {
                int timeStamp = (int)c["created_utc"];
                DateTime utc = DateTimeOffset.FromUnixTimeSeconds(timeStamp).DateTime;
                DateTimeOffset roundedTime = new DateTime(utc.Year, utc.Month, utc.Day).ToUniversalTime();
                return roundedTime.Ticks;
            };
            // Define method to get integer score
            Func<JToken, int> score = c => (int)c["score"];
            // Define method to get comment body
            Func<JToken, String> body = c => (String)c["body"];
            // Sort by day, then by score
            return this.comments["comments"]
                .OrderByDescending(timeStampDay)
                .ThenByDescending(score)
                .Select(body)
                .First();
        }
        
        /// <summary>
        /// Find the subreddit with the most comments
        /// </summary>
        public String mostActiveSub()
        {
            return (String) this.comments["comments"]
                .GroupBy(c => (String)c["subreddit"])
                .OrderByDescending(g => g.Count())
                .First().First()["subreddit"];
        }

        /// <summary>
        /// Checks if any comments are gilded
        /// </summary>
        /// <returns>True if at least one comment is gilded</returns>
        public bool anyGold()
        {
            return this.comments["comments"]
                .Any(c => (int)c["gilded"] == 1);
        }

        /// <summary>
        /// Comparison class for checking if two comments come from the same sub
        /// </summary>
        class SubComparer : IEqualityComparer<JToken>
        {
            /// <summary>
            /// Verifying both comments have the same (case-insensitive) subreddit
            /// </summary>
            /// <param name="c1">The first comment</param>
            /// <param name="c2">The second comment</param>
            /// <returns>True if they are from the same sub</returns>
            public bool Equals(JToken c1, JToken c2)
            {
                return ((String) c1["subreddit"]).ToLower() == ((String) c2["subreddit"]).ToLower();
            }
            public int GetHashCode(JToken obj)
            {
                return obj.GetHashCode();
            }
        }
        
        /// <summary>
        /// Checks if any comments are from a particular subreddit, using a custom comparer class to 
        /// compare comments purely on their subreddit (and not by reference).
        /// </summary>
        /// <returns></returns>
        public bool anyFromSub(String sub)
        {
            JObject keySub = new JObject();
            keySub.Add("subreddit", sub);

            return this.comments["comments"]
                .Contains(keySub, new SubComparer());
        }

        /// <summary>
        /// Calculate Average score using aggregation
        /// </summary>
        /// <returns>Average comment score</returns>
        public double averageScoreAgg()
        {
            // Aggregate all the comment scores 
            int totalScore = this.comments["comments"]
                .Aggregate<JToken, int>(0, (s, c) => s += (int)c["score"]);
            // Divide total score by num comments
            return totalScore / (double) this.getNumComments();
        }

        /// <summary>
        /// Calculate average score using average method
        /// </summary>
        /// <returns>Average comment score</returns>
        public double averageScore()
        {
            return this.comments["comments"].Average(c => (int)c["score"]);
        }

    }
}
