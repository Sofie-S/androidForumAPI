﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post GetBy(int postId);
        void Add(Post post);
        void SaveChanges();
    }
}
