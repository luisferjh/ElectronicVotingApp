using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicVote.Web.Repository.Candidates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicVote.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Voter")]
    public class ImageCandidateController : ControllerBase
    {
        private readonly IImgCandidateRepository _imgcandidateRepository;
        public ImageCandidateController(IImgCandidateRepository imgcandidateRepository)
        {
            _imgcandidateRepository = imgcandidateRepository;
        }

        // GET: api/ImageCandidate/5
        [HttpGet("[action]/{id}.png")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var imageSearch = await _imgcandidateRepository.GetImgCandidate(id);            
            var image = System.IO.File.ReadAllBytes(imageSearch.ImagePath);

            return File(image, "image/png");
        }
    }
}
