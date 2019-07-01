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

        // GET: api/Vote


        // GET: api/Vote/5
        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetMostVoted()
        {
            //_voteRepository.GetCandidateMostVoted();           
            var candidate = _voteRepository.GetCandidateMostVoted();
            return Ok(candidate);
        }

        // GET: api/GetVoteCandidate/5
        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetVoteCandidate()
        {       
            var votes = _voteRepository.GetCandidate(6);

            return Ok(votes);
        }

        // POST: api/Vote
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
