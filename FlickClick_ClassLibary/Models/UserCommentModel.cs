﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    public class UserCommentModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int MovieID { get; set; }
        public string Title { get; set; }
    }
}
