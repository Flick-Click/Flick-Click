﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class UserCommetModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int MovieID { get; set; }
        public string Title { get; set; }
    }
}