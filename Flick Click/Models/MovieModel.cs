using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class MovieModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public TimeSpan Relaease { get; set; }
        public TimeSpan Created { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string TrailerLink { get; set; }

        //find a sulusen to get mor the 1 director and writer
        //public List<DirecotorModel> Director { get; set; }
        //public List<WriterModel> Writers { get; set; }


    }
}