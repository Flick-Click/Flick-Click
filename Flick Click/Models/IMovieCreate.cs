using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flick_Click.Models
{
    public interface IMovieCreate
    {
        List<GenresModel> Genre { get; set; }
        List<DirectorModel> Directors { get; set; }
        List<DirectorModel> Writers { get; set; }
        List<AgeRatingModel> Age_rating { get; set; }
        HttpPostedFileBase ImageFile { get; set; }
    }
}