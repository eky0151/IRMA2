using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace IrmaProject.Models
{
    public class RegistrationModel
    {
        [DisplayName("First name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("User name")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DisplayName("Password again")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string PasswordAgain { get; set; }

        public bool RegirectToLogin { get; set; }


  }
}
