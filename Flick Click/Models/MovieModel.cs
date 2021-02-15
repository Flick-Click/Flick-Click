using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class MovieModel : IMovie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public DateTime Release { get; set; }
        public DateTime Created { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Trailer { get; set; }
        public int CommentCount { get; set; }
    }
}