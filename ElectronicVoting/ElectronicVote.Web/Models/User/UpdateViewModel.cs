using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.User
{
    public class UpdateViewModel
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Boolean Record { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Boolean Voted { get; set; }
    }
}
