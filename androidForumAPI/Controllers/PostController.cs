using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using androidForumAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace androidForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;

        }

        /// <summary>
        /// Get all posts ordered by most recent
        /// </summary>
        /// <returns>array of posts</returns>
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
                return _postRepository.GetAll();
        }

        /// <summary>
        /// Get the post with given id
        /// </summary>
        /// <param name="id">the id of the post</param>
        /// <returns>returns the post with the given id</returns>
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {
            Post post = _postRepository.GetBy(id);
            if (post == null) return NotFound();

            return post;
        }


    }
}