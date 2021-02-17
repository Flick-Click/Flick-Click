using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static FlickClick_ClassLibary.BusinessLogic.SearchProcess;
using Flick_Click.Models;
using System.Web.Mvc;

namespace Flick_Click.Controllers
{
    public class SearchController : Controller
    {

        // GET: Search
        public ActionResult Search()
        {
            return View();
        }

        // GET: SearchResult
        public ActionResult SearchResult(string Search)
        {
            var data = LoadSearchedMovies(Search);
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    Img = movie.Picture_Path
                });
            }

            return View(Movies);
        }
    }
}