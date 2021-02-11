using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class MovieCommentCountModel: IMovie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public TimeSpan Relaease { get; set; }
        public TimeSpan Created { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int CommentCount { get; set; }
        public int Rating { get; set; }
    }
}