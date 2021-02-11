using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    interface IMovie
    {
        int ID { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int Duration { get; set; }
        DateTime Release { get; set; }
        DateTime Created { get; set; }
        string Trailer { get; set; }
        string Picture_Path { get; set; }
        int Rating { get; set; }
    }
}
