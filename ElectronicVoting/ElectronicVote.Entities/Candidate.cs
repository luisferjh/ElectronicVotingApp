using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ElectronicVote.Entities
{
    public class Candidate
    {
        public int IdCandidate { get; set; }    
        public string FullName { get; set; }
        //public Byte[] Picture { get; set; }
        public Boolean State { get; set; }

        //Navigation Properties
        public ICollection<Vote> Votes { get; set; }
        public ImageCandidate ImageCandidate { get; set; }
    }
}
