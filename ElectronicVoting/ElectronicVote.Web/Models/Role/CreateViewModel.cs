using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.Role
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Please enter RoleName")]      
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name Role must not have more than 30 characters, or less than 5 characters.")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Please enter Condition")]
        public Boolean Condition { get; set; }
    }
}
