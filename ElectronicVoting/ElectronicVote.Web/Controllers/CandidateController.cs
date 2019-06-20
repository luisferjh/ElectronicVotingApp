using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Web.Models.Candidate;
using ElectronicVote.Web.Repository.Candidates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicVote.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        // GET: api/Candidate
        [HttpGet("[action]")]
        public async Task<IEnumerable> Listar()
        {
            var Candidates = await _candidateRepository.List();
            return Candidates;
        }

        // GET: api/Candidate/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var candidate = await _candidateRepository.GetCandidate(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        // POST: api/Candidate/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateViewModel candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _candidateRepository.AddCandidate(candidate);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(candidate);
        }

        // PUT: api/Candidate/Update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.IdCandidate <= 0)
            {
                return BadRequest();
            }

            try
            {
                await _candidateRepository.UpdateCandidate(model);
            }
            catch (NullReferenceException)
            {
                if (!(await _candidateRepository.CandidateExists(model.IdCandidate)))
                {
                    return NotFound();
                }
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("[action]")]
        public void Delete(int id)
        {
        }
    }
}
