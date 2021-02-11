using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flick_Click.Models
{
    interface IMovie
    {
        int ID { get; set; }
        string Title { get; set; }
        string Img { get; set; }
        TimeSpan Relaease { get; set; }
        TimeSpan Created { get; set; }
        int Duration { get; set; }
        string Description { get; set; }
        int Rating { get; set; }
    }
}
