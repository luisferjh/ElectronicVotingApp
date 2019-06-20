using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Role
{
    public class RoleViewModel
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public Boolean Condition { get; set; }
    }
}
