using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Web.Models.User;
using ElectronicVote.Web.Repository.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicVote.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User/List
        [HttpGet("[action]")]
        public async Task<IEnumerable<UserViewModel>> List()
        {
            var users = await _userRepository.List();
            return users;
        }
 
        // GET: api/User/get/5
        [HttpGet("[action]/{id}")]  
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/User/getState/5
        [HttpGet("[action]/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetState([FromRoute] int id)
        {
            var userState = await _userRepository.StateUser(id);
            if (userState == null)
            {
                return NotFound();
            }

            return Ok(userState);
        }

        // POST: api/User/Create
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Age < 18)
            {
                return BadRequest();
            }

            try
            {
                await _userRepository.AddUser(model);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }        

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }       
    }
}
