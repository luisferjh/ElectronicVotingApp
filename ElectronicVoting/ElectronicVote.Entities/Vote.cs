using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Entities
{
    [Auditable]
    public class Vote
    {       
        public int IdUser { get; set; }
        public int IdCandidate { get; set; }

        // navigation properties
        public VoterUser User { get; set; }
        public Candidate Candidate { get; set; }
        
    }
}
