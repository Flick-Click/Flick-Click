using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flick_Click.Models
{
    public interface IPeople
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }
}
