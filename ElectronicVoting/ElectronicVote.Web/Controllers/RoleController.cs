using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Web.Models.Role;
using ElectronicVote.Web.Repository.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicVote.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/Role/List
        [HttpGet("[action]")]
        public async Task<IEnumerable> List()
        {
            var roles = await _roleRepository.List();
            return roles;
        }

        // GET: api/Role/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var role = await _roleRepository.GetRole(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);            
        }

        // POST: api/Role
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _roleRepository.AddRole(model);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Role/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            if (model.IdRole <= 0)
            {
                return BadRequest(model);
            }

            try
            {
                await _roleRepository.UpdateRole(model);
            }
            catch (NullReferenceException)
            {
                if (!(await _roleRepository.RoleExists(model.IdRole)))
                {
                    return NotFound();
                }
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(model);
        }
        
    }
}
