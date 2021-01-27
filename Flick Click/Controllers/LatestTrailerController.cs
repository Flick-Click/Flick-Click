using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flick_Click.Controllers
{
    public class LatestTrailerController : Controller
    {
        // GET: LatestTrailer
        public ActionResult Index()
        {
            return View();
        }
    }
}