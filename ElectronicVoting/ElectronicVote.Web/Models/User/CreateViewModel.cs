using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.User
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Please enter id role")]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(30, ErrorMessage = "Name must not have more than 30 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter age")]
        [Range(18,150, ErrorMessage = "Please enter correct value")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter Record")]
        public Boolean Record { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40, ErrorMessage = "Email must not have more than 40 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }          
    }
}
