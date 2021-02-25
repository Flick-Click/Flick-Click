using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class GenresModel
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int GenreID { get; set; }
        public string Genre { get; set; }
    }
}