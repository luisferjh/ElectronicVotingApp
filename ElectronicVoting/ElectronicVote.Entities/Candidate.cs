using System;

namespace ElectronicVote.Entities
{
    public class Candidate
    {
        public int IdCandidate { get; set; }
        public string FullName { get; set; }
        public Byte Picture { get; set; }
        public Boolean State { get; set; }
        //Navigation Properties
        public Vote Vote { get; set; }
    }
}
