using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlickClick_ClassLibary.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int MovieID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
    }
}