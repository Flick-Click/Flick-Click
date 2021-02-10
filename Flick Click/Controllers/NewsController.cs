using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.NewsProcess;
using Flick_Click.Models;

namespace Flick_Click.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult News()
        {
            var data = LoadNews();
            List<NewsModel> news = new List<NewsModel>();

            foreach (var row in data)
            {
                news.Add(new NewsModel
                {
                    ID = row.ID,
                    Title = row.Title,
                    Content = row.Content,
                    Created = row.Created
                });
            }

            return View(news);
        }

        // GET: NewsDetails
        public ActionResult NewsDetails(int id)
        {

            var data = LoadSingleNews(id);

            List<NewsModel> news = new List<NewsModel>();

            foreach (var row in data)
            {
                news.Add(new NewsModel
                {
                    Title = row.Title,
                    Content = row.Content,
                    Created = row.Created
                });
            }

            return View(news);
        }

        // GET: Create
        public ActionResult Create()
        {

            return View();
        }
    }
}