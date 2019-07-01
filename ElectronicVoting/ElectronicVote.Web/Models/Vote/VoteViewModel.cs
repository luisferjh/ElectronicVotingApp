using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Vote
{
    public class VoteViewModel
    {
        public int idCandidate { get; set; }
        public int TotalVotes { get; set; }
    }
}
