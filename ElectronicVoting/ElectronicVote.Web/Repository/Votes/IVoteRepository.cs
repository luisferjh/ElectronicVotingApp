using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Web.Models.Vote;

namespace ElectronicVote.Web.Repository.Votes
{
    public interface IVoteRepository
    {          
        CandidateVotedViewModel GetCandidateMostVoted();
        VotesByCandidateViewModel ListCandidateVoted();
        Task<CandidateVotedViewModel> GetCandidate(int id);
        Task AddVote(CreateViewModel model);
      
    }
}
