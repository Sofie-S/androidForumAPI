using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Models
{
    public class Post
    {
        public long PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public string CreatorName { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
        public int ReactionAmount { get; set; }

        public void AddReaction(Reaction reaction)
        {
            Reactions.Add(reaction);
            ReactionAmount++;
        }
    }
}
