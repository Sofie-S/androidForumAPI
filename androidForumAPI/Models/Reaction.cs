using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Models
{
    public class Reaction
    {
        public long ReactionId { get; set; }
        public string ReactionDescription { get; set; }
        public string CreatorName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
