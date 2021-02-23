using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flick_Click.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to give us your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "You need to give us your last name.")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You need to give us your Email Address.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("EmailAddress", ErrorMessage = "The email and Confirm Email must match.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "You need to provide a long enough password.")]
        [Required(ErrorMessage = "You need to set a password.")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "You need to provide a long enough password.")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "TelefonNummer")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "You need to provide a long enough TelefonNummer.")]
        public string TelefonNummer { get; set; }
        
        public string Group { get; set; }
    }
}
