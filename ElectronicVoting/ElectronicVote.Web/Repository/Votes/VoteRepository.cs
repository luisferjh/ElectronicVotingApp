using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Data;
using ElectronicVote.Entities;
using ElectronicVote.Web.Models.Vote;

namespace ElectronicVote.Web.Repository.Votes
{
    public class VoteRepository : IVoteRepository
    {
        private readonly DbContextElectronicVote _context;       

        public VoteRepository(DbContextElectronicVote context)
        {
            _context = context;           
        }

        public async Task AddVote(CreateViewModel model)
        {
            Vote vote = new Vote
            {
                IdUser = model.IdUser,
                IdCandidate = model.IdCandidate
            };

            await _context.Votes.AddAsync(vote);         

            var user = await _context.VoterUsers.FindAsync(model.IdUser);
            user.Voted = true;

            _context.SaveChanges();
        }

        public CandidateVotedViewModel GetCandidate(int id)
        {
            var candidateVotes = _context.Votes.Where(v => v.IdCandidate == id).Count();
            var candidate =  _context.Candidates.Find(id);

            return new CandidateVotedViewModel
            {
                CandidateName = candidate.FullName,
                NumVotes = candidateVotes
            };
        }

        public void GetCandidateMostVoted()
        {
            var vote = _context.Votes.Select(v => v.IdCandidate).Count();         

            Console.WriteLine(vote);

            //var candidate = await _context.Candidates(vote.);

            //return new CandidateMostVotedViewModel
            //{
            //    CandidateName =
            //    NumVotes = vote;
            //};
        }
       

        //public Task<IEnumerable<UserViewModel>> List()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
