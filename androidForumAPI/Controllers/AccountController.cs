using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using androidForumAPI.DTO;
using androidForumAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace androidForumAPI.Controllers
{
    /// <summary>
    /// the controller responsible for all api calls for accounts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _config;

        public AccountController(
          SignInManager<IdentityUser> signInManager,
          UserManager<IdentityUser> userManager,
          ICustomerRepository customerRepository,
          IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _customerRepository = customerRepository;
            _config = config;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model">the login details</param>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoggedInUser>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    return Created("", new LoggedInUser(user.UserName));     

                }
            }
            return BadRequest();
        }

        /// <summary>
        /// checks if username is already taken
        /// </summary>
        /// <param name="username"></param>
        /// <returns>returns true if user does not exist</returns>
        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>> CheckAvailableUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user == null;
        }

        private String GetToken(IdentityUser user)
        {
            // Create the token
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              null, null,
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}