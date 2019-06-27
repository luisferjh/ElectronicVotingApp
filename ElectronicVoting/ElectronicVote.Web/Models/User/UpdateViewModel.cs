using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicVote.Web.Models.User
{
    public class UpdateViewModel
    {
        [Required(ErrorMessage = "Please enter id user")]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Please enter id role")]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(30, ErrorMessage = "Name must not have more than 30 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter record")]
        public Boolean Record { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [StringLength(40, ErrorMessage = "Email must not have more than 40 characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }      

        [Required(ErrorMessage = "Please enter voted")]
        public Boolean Voted { get; set; }
    }
}
