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

        // GET: News
        public ActionResult NyNews()
        {
            var data = LoadNyNews();
            List<NewsModel> news = new List<NewsModel>();

            if (data.Count >= 3)
            {
                for (int i = 0; i <= 2; i++)
                {
                    news.Add(new NewsModel
                    {

                        ID = data[i].ID,
                        Title = data[i].Title,
                        Content = data[i].Content,
                        Created = data[i].Created
                    });
                }
            }
            else
            {
                for (int i = 0; i <= data.Count - 1; i++)
                {
                    news.Add(new NewsModel
                    {
                        ID = data[i].ID,
                        Title = data[i].Title,
                        Content = data[i].Content,
                        Created = data[i].Created
                    });
                }
            }

            return PartialView(news);
        }

        // ----------------- Create Section ------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsModel model)
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    if (ModelState.IsValid)
                    {
                        CreateNews(model.Title, model.Content);
                        return RedirectToAction("News", "News");
                    }

                    return View();
                }
            }
            return RedirectToAction("News", "News");
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
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    return View();
                }
            }
            return RedirectToAction("News", "News");
        }

        // Get: EditNews
        public ActionResult EditNews(int id)
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
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
            }
            return RedirectToAction("News", "News");
        }

        // ----------------- Update Section ------------------
        [HttpPost]
        public ActionResult SaveEditNews(NewsModel model)
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    UpdateNews(model.ID, model.Title, model.Content);

                    return RedirectToAction("NewsDetails", "News", new { id = model.ID });
                }
            }
            return RedirectToAction("News", "News");
        }

        // ----------------- Delete Section ------------------
        [HttpPost]
        public ActionResult DeleteNews(Nullable<int> id)
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    Deletenews(id);

                    return RedirectToAction("News", "News");
                }
            }
            return RedirectToAction("News", "News");
        }
    }
}