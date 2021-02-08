using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flick_Click.Controllers
{
    public class MostCommentedMovieController : Controller
    {
        // GET: MostCommetedMovie
        public ActionResult MostCommentedMovie()
        {
            return View();
        }
    }
}