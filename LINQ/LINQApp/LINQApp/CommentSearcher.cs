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
       
        // TODO: fix dis
        public IEnumerable<String> stringSearch(String term)
        {
            return from c in this.comments["commnets"]
                   where ((String) c["body"]).Contains(term)
                   select (String) c["body"];
        }
    }
}
