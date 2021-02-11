using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.MovieProcess;
using Flick_Click.Models;


namespace Flick_Click.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadMovies()
        {
            var data = LoadLatestMovies();
            List<MovieCommentCountModel> Movies = new List<MovieCommentCountModel>();

            for (int i = 0; i <= 5; i++)
            {
                Movies.Add(new MovieCommentCountModel
                {
                    ID = data[i].ID,
                    Title = data[i].Title,
                    Img = data[i].Picture_Path,
                    CommentCount = data[i].CommentCount
                });
            }

            return View(Movies);
        }

        public ActionResult LoadMostCommentedMovies()
        {
            var data = LoadMovieMostComments();
            List<MovieCommentCountModel> Movies = new List<MovieCommentCountModel>();

            for (int i = 0; i <= 5; i++)
            {
                Movies.Add(new MovieCommentCountModel
                {
                    ID = data[i].ID,
                    Title = data[i].Title,
                    Img = data[i].Picture_Path,
                    CommentCount = data[i].CommentCount
                });
            }

            return View(Movies);
        }
    }
}