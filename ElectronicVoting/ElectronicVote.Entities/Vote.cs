using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Entities
{
    public class Vote
    {
        public int IdUser { get; set; }
        public int IdCandidate { get; set; }

        // navigation properties
        public ICollection<VoterUser> Users { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
        
    }
}
