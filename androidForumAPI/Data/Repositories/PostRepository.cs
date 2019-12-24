using androidForumAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(PostContext dbContext)
        {
            _context = dbContext;
            _posts = dbContext.Posts;
        }

        public IEnumerable<Post> getAll()
        {
            return _posts.OrderByDescending(p => p.DateAdded);
        }

        public Post GetBy(int postId)
        {
            return _posts.SingleOrDefault(p => p.PostId == postId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
