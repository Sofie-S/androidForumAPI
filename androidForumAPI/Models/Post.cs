using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public string CreatorName { get; set; }
        public DateTime DateAdded { get; set; }
        public int LikesAmount { get; set; }
        public int ReactionAmount { get; set; }
        
    }
}
