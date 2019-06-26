using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.User
{
    public class UserLoginViewModel
    {
        public int IdUser { get; set; }
        public int IdRole { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Boolean Record { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Boolean Voted { get; set; }
    }
}
