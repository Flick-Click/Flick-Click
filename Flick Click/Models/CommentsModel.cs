using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class CommentsModel
    {
        public int ID { get; set; }
        public int Movie_ID { get; set; }
        public int User_ID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
    }
}