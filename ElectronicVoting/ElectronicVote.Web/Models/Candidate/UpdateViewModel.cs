using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Candidate
{
    public class UpdateViewModel
    {
        [Required(ErrorMessage = "Please enter Id Candidate")]
        public int IdCandidate { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Name must not have more than 30 characters, or less than 4 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter state")]
        public Boolean State { get; set; }

        [Required(ErrorMessage = "Please enter Path image")]
        public string ImagePath { get; set; }
    }
}
