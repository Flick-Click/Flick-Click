using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.MovieProcess;
using Flick_Click.Models;

namespace Flick_Click.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult MovieDetails()
        {
            return View();
        }

        // GET: MostCommentedMovie
        public ActionResult MostCommentedMovie()
        {
            var data = LoadMovieMostComments();
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    Img = movie.Picture_Path,
                    CommentCount = movie.CommentCount
                });
            }

            return View(Movies);
        }

        // GET: LatestTrailer
        public ActionResult LatestMovies()
        {
            var data = LoadLatestMovies();
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    Img = movie.Picture_Path,
                    CommentCount = movie.CommentCount
                });
            }

            return View(Movies);
        }

        // GET: ShowAll
        public ActionResult ShowAll()
        {
            var data = LoadMovies();
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    Img = movie.Picture_Path,
                    CommentCount = movie.CommentCount
                });
            }

            return View(Movies);
        }

    }
}