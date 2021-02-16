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
        public int Movie_ID { get; set; }
        public int Genre_ID { get; set; }
        public string Genre { get; set; }
    }
}
