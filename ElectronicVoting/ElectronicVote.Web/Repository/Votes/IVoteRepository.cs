using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Web.Models.Vote;

namespace ElectronicVote.Web.Repository.Votes
{
    public interface IVoteRepository
    {
        //Task<IEnumerable<UserViewModel>> List();
        //Task<CandidateVotedViewModel> GetCandidateMostVoted(int id);
        void GetCandidateMostVoted();
        CandidateVotedViewModel GetCandidate(int id);
        Task AddVote(CreateViewModel model);              
    }
}
