using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using androidForumAPI.DTO;
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
        private readonly ICustomerRepository _customerRepository;

        public PostController(IPostRepository postRepository, ICustomerRepository customerRepository)
        {
            _postRepository = postRepository;
            _customerRepository = customerRepository;

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

        // POST: api/Post
        /// <summary>
        /// Adds a new post
        /// </summary>
        /// <param name="post">the new post</param>
        /// <returns>returns status 201 when succesfully created and 400 when something went wrong</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Post> AddPost([FromBody] PostDTO post)
        {
            Post createdPost = new Post() { PostTitle = post.PostTitle, PostDescription = post.PostDescription, CreatorName = post.CreatorName, DateAdded = post.DateAdded };

            _postRepository.Add(createdPost);
            _postRepository.SaveChanges();

            return CreatedAtAction(nameof(GetPost), new { id = createdPost.PostId }, post);
        }

        // POST: api/Post
        /// <summary>
        /// Adds a new reaction to a post
        /// </summary>
        /// <returns>returns status 201 when succesfully created and 400 when something went wrong</returns>
        [HttpPut("{postId}/addReaction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Post> AddReaction(int postId, [FromBody] ReactionDTO reaction)
        {
            Post post = _postRepository.GetBy(postId);
            Reaction createdReaction = new Reaction() { ReactionDescription = reaction.ReactionDescription, ReactionId = 0,  CreatorName = reaction.CreatorName, DateAdded = post.DateAdded };

            post.AddReaction(createdReaction);
            _postRepository.SaveChanges();

            return CreatedAtAction(nameof(AddReaction), new { id = createdReaction.ReactionId }, createdReaction);
        }
    }

}