using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Entities
{
    public class VoterUser
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }       
        public string FullName { get; set; }
        public int Age { get; set; }
        public Boolean Record { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Boolean Voted { get; set; }
    

        // navigation properties
        public Role Role { get; set; }
        public Vote Vote { get; set; }
    }
}
