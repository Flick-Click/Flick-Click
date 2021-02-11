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
        [HttpPost]
        // GET: Seach
        public ActionResult Search(string GSearch)
        {
            return View();
            var data = LoadMovies(GSearch);
            string Search = GSearch;

            foreach(var row in data)
        }
    }
}