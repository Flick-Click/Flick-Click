using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    public interface IPeople
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }
}
