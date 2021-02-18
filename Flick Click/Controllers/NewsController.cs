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

        // ----------------- List Section ------------------

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

        // ----------------- Create Section ------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsModel model)
        {
            if (ModelState.IsValid)
            {
                CreateNews(model.Title, model.Content);
                return RedirectToAction("News", "News");
            }

            return View();
        }

        // ----------------- Read Section ------------------

        // GET: NewsDetails
        public ActionResult NewsDetails(Nullable<int> id)
        {

            var data = LoadSingleNews(id);

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

        // Get: News
        public ActionResult Create()
        {
            return View();
        }

        // Get: EditNews
        public ActionResult EditNews(int id)
        {
            var data = LoadSingleNews(id);
            NewsModel news = new NewsModel
            {
                ID = id,
                Title = data[0].Title,
                Content = data[0].Content
            };
            
            return View(news);
        }

        // ----------------- Update Section ------------------
        [HttpPost]
        public ActionResult SaveEditNews(NewsModel model)
        {
            UpdateNews(model.ID, model.Title, model.Content);

            return RedirectToAction("NewsDetails", "News", new { id = model.ID });
        }

        // ----------------- Delete Section ------------------
        [HttpPost]
        public ActionResult DeleteNews(Nullable<int> id)
        {
            Deletenews(id);

            return RedirectToAction("News", "News");
        }
        

    }
}