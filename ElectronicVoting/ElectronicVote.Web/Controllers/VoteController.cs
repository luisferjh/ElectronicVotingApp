using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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

        // GET: api/Vote/ListVotes
        [HttpGet("[action]/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<VotesByCandidateViewModel>> ListVotes()
        {            
            return null;
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
        [Authorize(Roles = "Admin,Voter")]
        public async Task<IActionResult> ToVote([FromBody] CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //coment
            //using (var scope = new TransactionScope())
            //{
                try
                {
                    await _voteRepository.AddVote(model);
                    //scope.Complete();
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
            //}                     
        }
       
    }
}
