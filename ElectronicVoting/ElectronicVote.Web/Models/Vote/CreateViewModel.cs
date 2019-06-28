using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Vote
{
    public class CreateViewModel
    {
        [Required]
        public int IdUser { get; set; }
        [Required]
        public int IdCandidate { get; set; }
    }
}
