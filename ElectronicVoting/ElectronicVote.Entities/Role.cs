using System;
using System.Collections.Generic;

using System.Text;

namespace ElectronicVote.Entities
{
    public class Role
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public Boolean Condition { get; set; }

        // navigation properties
        public ICollection<VoterUser> Users { get; set; }
    }
}
