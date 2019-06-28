using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Vote
{
    public class CandidateVotedViewModel
    {
        public string CandidateName { get; set; }
        public int NumVotes { get; set; }
    }
}
