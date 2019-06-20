using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Data;
using ElectronicVote.Web.Models.Candidate;

namespace ElectronicVote.Web.Repository.Candidates
{
    public class ImgCandidateRepository : IImgCandidateRepository
    {
        private readonly DbContextElectronicVote _context;
        public ImgCandidateRepository(DbContextElectronicVote context)
        {
            _context = context;
        }

        public async Task<ImgCandidateViewModel> GetImgCandidate(int id)
        {            
            var imgCand = await _context.ImageCandidates.FindAsync(id);            

            if (imgCand == null)
            {
                return null;
            }

            return new ImgCandidateViewModel
            {
                ImagePath = imgCand.ImagePath            
            };
        }
    }
}
