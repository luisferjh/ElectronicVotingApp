using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Entities
{
    public class ImageCandidate
    {
        public int IdCandidate { get; set; }
        public string ImagePath { get; set; }

        //navigation property
        public Candidate Candidate { get; set; }
    }
}
