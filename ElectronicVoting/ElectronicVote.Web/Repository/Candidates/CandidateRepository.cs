using ElectronicVote.Data;
using ElectronicVote.Entities;
using ElectronicVote.Web.Models.Candidate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Repository.Candidates
{
    public class CandidateRepository:ICandidateRepository
    {
        private readonly DbContextElectronicVote _context;
        public CandidateRepository(DbContextElectronicVote context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateViewModel>> List()
        {
            var candidates = await _context.Candidates
                .Include(c => c.ImageCandidate)
                .ToListAsync();

            return candidates.Select(c => new CandidateViewModel
            {
                IdCandidate = c.IdCandidate,
                FullName = c.FullName,
                Picture = $"https://localhost:44397/api/ImageCandidate/get/{c.ImageCandidate.IdCandidate}.png",
                State = c.State
            });

        }

        public async Task<CandidateViewModel> GetCandidate(int id)
        {
            var candidate = await _context.Candidates
                .Include(c => c.ImageCandidate)
                .FirstAsync(c => c.IdCandidate == id);            

            if (candidate == null)
            {
                return null;
            }

            return new CandidateViewModel
            {
                IdCandidate = candidate.IdCandidate,
                FullName = candidate.FullName,
                State = candidate.State,
                Picture = $"https://localhost:44397/api/ImageCandidate/get/{candidate.IdCandidate}.png"                
                //candidate.ImageCandidate.ImagePath
            };
        }

        public async Task AddCandidate(CreateViewModel model)
        {          
            var candidate = new Candidate
            {
                FullName = model.FullName,              
                State = model.State
            };

            await _context.Candidates.AddAsync(candidate);

            await _context.SaveChangesAsync();

            // add image candidate
            var idImgCandidate = candidate.IdCandidate;

            var imgCandidate = new ImageCandidate
            {
                IdCandidate = idImgCandidate,
                ImagePath = model.ImagePath
            };

            await _context.ImageCandidates.AddAsync(imgCandidate);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCandidate(UpdateViewModel model)
        {
            var candidate = await _context.Candidates
                .Include(c => c.ImageCandidate)
                .FirstAsync(c => c.IdCandidate == model.IdCandidate);

            candidate.IdCandidate = model.IdCandidate;
            candidate.FullName = model.FullName;
            candidate.ImageCandidate.ImagePath = model.Picture;
            candidate.State = candidate.State;

            await _context.SaveChangesAsync();
        }

        public Task DeleteCandidate(Candidate Pcandidate)
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> SearchCandidateById(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return null;
            }

            return candidate;
        }

        public async Task<bool> CandidateExists(int id)
        {
            return await _context.Candidates.AnyAsync(c => c.IdCandidate == id);
        }
    }
}
