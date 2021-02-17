using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    public class MovieModel : IMovie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime Release { get; set; }
        public DateTime Created { get; set; }
        public string Trailer { get; set; }
        public string Picture_Path { get; set; }
        public int Rating { get; set; }
        public int CommentCount { get; set; }
        public int Age_Rating { get; set; }
    }
}
