using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.DTO
{
    public class ReactionDTO
    {
        [Required]
        public string ReactionDescription { get; set; }
        public string CreatorName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
