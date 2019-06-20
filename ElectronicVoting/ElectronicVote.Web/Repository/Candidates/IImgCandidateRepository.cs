using ElectronicVote.Web.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Repository.Candidates
{
    public interface IImgCandidateRepository
    {
        Task<ImgCandidateViewModel> GetImgCandidate(int id);
    }
}
