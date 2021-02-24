using Flick_Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.MovieProcess;
using static FlickClick_ClassLibary.BusinessLogic.NewsProcess;
using static FlickClick_ClassLibary.BusinessLogic.CommentProcess;
using static FlickClick_ClassLibary.BusinessLogic.UserProcess;

namespace Flick_Click.Controllers
{
    public class AdministrationController : Controller
    {

        // ----------------- Read Section ------------------

        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        // GET: AllMovies
        public ActionResult AllMovies()
        {
            var data = LoadMovies();
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title
                });
            }

            return View(Movies);
        }

        // GET: News
        public ActionResult AllNews()
        {
            var data = LoadNews();
            List<NewsModel> news = new List<NewsModel>();

            foreach (var row in data)
            {
                news.Add(new NewsModel
                {
                    ID = row.ID,
                    Title = row.Title,
                    Created = row.Created
                });
            }

            return View(news);
        }

        // GET: News
        public ActionResult AllComments()
        {
            var data = LoadAllComments();
            List<CommentsModel> Comments = new List<CommentsModel>();

            foreach (var row in data)
            {
                Comments.Add(new CommentsModel
                {
                    ID = row.ID,
                    Name = row.Name,
                    Movie_ID = row.Movie_ID,
                    Content = row.Content,
                    Created = row.Created
                });
            }

            return View(Comments);
        }

        // GET: News
        public ActionResult Allusers()
        {
            var data = LoadAllUsers();
            List<UserModel> Comments = new List<UserModel>();

            foreach (var row in data)
            {
                Comments.Add(new UserModel
                {
                    ID = row.ID,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.Email,
                    TelefonNummer = row.TlfNr,
                    Group = row.Group

                });
            }

            return View(Comments);
        }

        // ----------------- Delete Section ------------------

        public ActionResult DeleteMovie(int id)
        {
            Deletemovie(id);

            return RedirectToAction("../Administration/AllMovies");
        }

        public ActionResult DeleteNews(int id)
        {
            Deletenews(id);

            return RedirectToAction("../Administration/AllNews");
        }

        public ActionResult Deletecomment(int id)
        {
            DeleteComment(id);

            return RedirectToAction("../Administration/AllComments");
        }

        public ActionResult DeleteUser(int id)
        {
            Deleteuser(id);
            return RedirectToAction("../Administration/Allusers");
        }
    }
}