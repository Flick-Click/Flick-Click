using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.Models
{
    public class GenreModel
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int GenreID { get; set; }
        public string Genre { get; set; }
    }
}
