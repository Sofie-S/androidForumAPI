using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Models
{
    interface IPostRepository
    {
        IEnumerable<Post> getAll();
        Post GetBy(int postId);
        void SaveChanges();
    }
}
