using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flick_Click.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult MovieDetails()
        {
            return View();
        }
        public ActionResult MostCommentedMovie()
        {
            return View();
        }
        public ActionResult LatestTrailer()
        {
            return View();
        }
    }
}