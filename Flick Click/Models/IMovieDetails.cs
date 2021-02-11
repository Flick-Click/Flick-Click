using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flick_Click.Models
{
    interface IMovieDetails
    {
        List<RatingModel> Ratings { get; set; }
        List<ConnentModel> MyProperty { get; set; }
        List<DirecotorModel> Director { get; set; }
        List<WriterModel> Writer { get; set; }
    }
}
