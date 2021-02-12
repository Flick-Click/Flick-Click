using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class ContentModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public TimeSpan Created { get; set; }
    }
}