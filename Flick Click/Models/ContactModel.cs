using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class ContactModel
    {
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "You need to write you full name")]
        public string Name { get; set; }

        [Display(Name = "Email Address:")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to give us a email so we can write back")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Text)]
        [StringLength(1000, MinimumLength = 30, ErrorMessage = "Write a minimum of 30 Characters")]
        [Required(ErrorMessage = "It is Probably a good Idea too write a messege if you want to contact us")]
        public string Messege { get; set; }
    }
}