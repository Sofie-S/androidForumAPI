using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.Models
{
    public class Customer
    {
        #region Properties
        //add extra properties if needed
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public ICollection<Post> MyPosts { get; set; }

        #endregion

        #region Constructors
        public Customer()
        {
            MyPosts = new List<Post>();
        }
        #endregion

        #region Methods

        public void AddPost(Post post)
        {
            MyPosts.Add(post);
        }
        #endregion
    }
}

