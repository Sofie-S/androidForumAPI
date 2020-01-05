using androidForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace androidForumAPI.DTO
{
    public class LoggedInUser
    {
        public String UserName { get; set; }

        public LoggedInUser(String userName)
        {
            UserName = userName;
        }
    }
}
