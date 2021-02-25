using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [RegularExpression("([0-5])", ErrorMessage = "The rating must be between 0 and 5")]
        public int Rating { get; set; }
        public int CommentCount { get; set; }

        [Required(ErrorMessage = "Select minimum one Genre before creating a movie")]
        public List<GenresModel> Genre { get; set; }

        [Required(ErrorMessage = "Select minimum one Director before creating a movie")]
        public List<DirectorModel> Directors { get; set; }

        [Required(ErrorMessage = "Select minimum one Writer before creating a movie")]
        public List<DirectorModel> Writers { get; set; }
        public List<DirectorModel> People { get; set; }
        public List<AgeRatingModel> Age_rating { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}