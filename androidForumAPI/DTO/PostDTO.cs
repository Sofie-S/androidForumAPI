using androidForumAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.DTO
{
    public class PostDTO
    {
        public long PostId { get; set; }
        [Required]
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public DateTime DateAdded { get; set; }
        public IList<ReactionDTO> Reactions { get; set; }
        public string CreatorName { get; set; }
        public int ReactionAmount { get; set; }

        #region constructors
        public PostDTO() { }

        public PostDTO(Post post)
        {
            Reactions = new List<ReactionDTO>();
            PostTitle = post.PostTitle;
            PostDescription = post.PostDescription;
            DateAdded = post.DateAdded;
            foreach (var i in post.Reactions)
                Reactions.Add(new ReactionDTO() { ReactionDescription = i.ReactionDescription, CreatorName = i.CreatorName, DateAdded = i.DateAdded });
            CreatorName = post.CreatorName;
        }
        #endregion
    }
}
