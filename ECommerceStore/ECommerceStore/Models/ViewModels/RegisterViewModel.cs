using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display( Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Your password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
