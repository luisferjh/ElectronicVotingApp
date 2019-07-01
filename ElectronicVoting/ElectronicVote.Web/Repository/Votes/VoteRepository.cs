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
            var candidate = _context.Candidates.Find(id);

            return new CandidateVotedViewModel
            {
                CandidateName = candidate.FullName,
                NumVotes = candidateVotes
            };
        }

        public CandidateVotedViewModel GetCandidateMostVoted()
        {
            //var vote = _context.Votes. .Select(v => v.IdCandidate).Count();         

            //Console.WriteLine(vote);   
            int votesMaximun = voteMax();
            Candidate candidate;
            CandidateVotedViewModel candidateMost = new CandidateVotedViewModel();

            var queryCandidateMostVoted = _context.Votes
               .GroupBy(v => v.IdCandidate)
               .Where(v => v.Count() == votesMaximun)
               .Select(v =>
               new 
               {
                   idCandidate = v.Key,
                    TotalVotes = v.Count()
               });

            foreach (var item in queryCandidateMostVoted)
            {
                candidate = _context.Candidates.Find(item.idCandidate);
                candidateMost.CandidateName = candidate.FullName;
                candidateMost.NumVotes = item.TotalVotes;
                Console.WriteLine(item);
            }          

            return candidateMost;
        }

        //Get highest vote
        public int voteMax()
        {
            var votes = _context.Votes
              .GroupBy(v => v.IdCandidate)
              .Select(v =>
              new
              {
                  idcandidate = v.Key,
                  idUserCount = v.Count()
              }).Max(v => v.idUserCount);

            return votes;
        }        
    }
}
