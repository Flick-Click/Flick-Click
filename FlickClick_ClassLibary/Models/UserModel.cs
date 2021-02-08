using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    class UserModel
    {

        public string FistName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ConfirmEmail { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string TelefonNummer { get; set; }
        public bool IsManager { get; set; } = false;
    }
}
