using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public class CreateMovieModel : IMovie, IMovieCreate
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime Release { get; set; }
        public DateTime Created { get; set; }
        public string Trailer { get; set; }
        [DisplayName("Upload Image")]
        public string Img { get; set; }
        public int Rating { get; set; }
        public int CommentCount { get; set; }
        public List<GenresModel> Genre { get; set; }
        public List<DirectorModel> Directors { get; set; }
        public List<DirectorModel> Writers { get; set; }
        public List<DirectorModel> People { get; set; }
        public List<AgeRatingModel> Age_rating { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}