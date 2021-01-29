using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class UserModel
    {
        [Display(Name = "Fisrst Name")]
        [Required(ErrorMessage = "You need to give us first name.")]
        public string FirstName { get ; set ; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to give us Last name.")]
        public string LastName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You need to provide a long enough password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare ("Password" ,ErrorMessage = "You password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmailAddress")]
        [Required(ErrorMessage = "You need to give us first name.")]
        public string EmailAddress  { get; set; }

        [Display(Name = "Confirm EmailAddress")]
        [Compare("EmailAddress", ErrorMessage = "The Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }

    }
}