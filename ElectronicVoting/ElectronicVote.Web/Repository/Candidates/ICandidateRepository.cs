using ElectronicVote.Web.Models.Candidate;
using System;
using System.Collections.Generic;
using ElectronicVote.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Repository.Candidates
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<CandidateViewModel>> List();
        Task<CandidateViewModel> GetCandidate(int id);
        Task AddCandidate(CreateViewModel model);
        Task UpdateCandidate(UpdateViewModel model);
        Task DeleteCandidate(Candidate Pcandidate);
        Task<bool> CandidateExists(int id);
        Task<Candidate> SearchCandidateById(int id);
    }
}
