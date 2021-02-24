using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    public class WritersModel: IPeople
    {
        public int movieID { get; set; }
        public int PeopleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
