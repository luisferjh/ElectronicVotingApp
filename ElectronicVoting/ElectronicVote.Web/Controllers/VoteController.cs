using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Web.Models.Vote;
using ElectronicVote.Web.Repository.Votes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicVote.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Voter")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteRepository _voteRepository;
        public VoteController(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        // GET: api/Vote/GetMostVoted
        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetMostVoted()
        {                    
            var candidate = _voteRepository.GetCandidateMostVoted();
            return Ok(candidate);
        }

        // GET: api/Vote/GetVoteCandidate/5
        [HttpGet("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetVoteCandidate([FromRoute] int id)
        {       
            var votes = await _voteRepository.GetCandidate(id);

            return Ok(votes);
        }

        // POST: api/Vote/ToVote
        [HttpPost("[action]")]
        public async Task<IActionResult> ToVote([FromBody] CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _voteRepository.AddVote(model);
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
       
    }
}
