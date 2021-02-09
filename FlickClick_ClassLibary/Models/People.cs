using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    public class People : IPeople
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
