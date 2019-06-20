using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Candidate
{
    public class CandidateViewModel
    {
        public int IdCandidate { get; set; }
        public string FullName { get; set; }
        //public Byte[] Picture { get; set; }
        public Boolean State { get; set; }
        public string Picture { get; set; }
    }
}
