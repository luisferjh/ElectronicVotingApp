using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Web.Models.User;
using ElectronicVote.Web.Repository.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ElectronicVote.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepositories;

        public LoginController(IUserRepository userRepositories)
        {
            _userRepositories = userRepositories;           
        }

        // POST: api/User/Login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userCredentials = await _userRepositories.Login(model);

            if (userCredentials == null)
            {
                return NotFound();
            }

            if (!_userRepositories.CheckPassword(model.password, userCredentials.PasswordHash, userCredentials.PasswordSalt))
            {
                return NotFound();
            }

            var token = _userRepositories.GenerateToken(userCredentials);

            return Ok(new { token = token });
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
