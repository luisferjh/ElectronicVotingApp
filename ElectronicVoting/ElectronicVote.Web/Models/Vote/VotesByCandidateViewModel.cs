using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Vote
{
    public class VotesByCandidateViewModel
    {
        public int IdCandidate { get; set; }
        public string  CandidateName { get; set; }
        public int NumVotes { get; set; }
    }
}
