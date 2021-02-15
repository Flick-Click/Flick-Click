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
        string Description { get; set; }
        int Duration { get; set; }
        DateTime Release { get; set; }
        DateTime Created { get; set; }
        string Trailer { get; set; }
        string Img { get; set; }
        int Rating { get; set; }
        int CommentCount { get; set; }
    }
}
