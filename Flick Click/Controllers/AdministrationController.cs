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
using static FlickClick_ClassLibary.BusinessLogic.ContactProcess;

namespace Flick_Click.Controllers
{
    public class AdministrationController : Controller
    {

        // ----------------- Read Section ------------------

        // GET: Administration
        public ActionResult Index()
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    return View();
                }
            }

            return RedirectToAction("index", "home");
        }

        // GET: AllMovies
        public ActionResult AllMovies()
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
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
            }

            return RedirectToAction("index", "home"); 
        }

        // GET: News
        public ActionResult AllNews()
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
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
            }

            return RedirectToAction("index", "home");
        }

        // GET: News
        public ActionResult AllComments()
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    var data = LoadAllComments();
                    List<CommentsModel> Comments = new List<CommentsModel>();

                    foreach (var row in data)
                    {
                        Comments.Add(new CommentsModel
                        {
                            ID = row.ID,
                            Name = row.Name,
                            MovieID = row.MovieID,
                            Content = row.Content,
                            Created = row.Created
                        });
                    }

                    return View(Comments);
                }
            }
            return RedirectToAction("index", "home");
        }

        // GET: News
        public ActionResult Allusers()
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
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
            }

            return RedirectToAction("index", "home");
        }

        // GET: User
        public ActionResult EditUserAdmin(Nullable<int> id)
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    var data = LoadUser(id);
                    UserModel User = new UserModel();
                    var user = Getuser();
                    ViewBag.user = new SelectList(user, "ID", "Group");

                    foreach (var row in data)
                    {

                        User.ID = row.ID;
                        User.FirstName = row.FirstName;
                        User.LastName = row.LastName;
                        User.Group_ID = row.Group_ID;
                    }

                    return View(User);
                }
            }

            return RedirectToAction("index", "home");
        }

        public ActionResult AllContacts()
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    var data = LoadContacts();
                    List<ContactModel> Contacts = new List<ContactModel>();

                    foreach (var row in data)
                    {
                        Contacts.Add(new ContactModel
                        {
                            ID = row.ID,
                            Name = row.Name,
                            EmailAddress = row.Email,
                            Messege = row.Message
                        });
                    }

                    return View(Contacts);
                }
            }

            return RedirectToAction("index", "home");
        }

        // ----------------- Update Section ------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserAdmin(UserModel model, FormCollection form)
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    int group;
                    int.TryParse(form["Group"], out group);
                    UpdateUserAdmin(model.ID, model.FirstName, model.LastName, group);

                    return RedirectToAction("../Administration/Allusers");
                }
            }

            return RedirectToAction("index", "home");
        }

        // ----------------- Delete Section ------------------

        public ActionResult Deletecontact(int id)
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    DeleteContact(id);

                    return RedirectToAction("../Administration/AllContacts");
                }
            }

            return RedirectToAction("index", "home");
        }

        public ActionResult DeleteMovie(int id)
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    Deletemovie(id);

                    return RedirectToAction("../Administration/AllMovies");
                }
            }

            return RedirectToAction("index", "home");
        }

        public ActionResult DeleteNews(int id)
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    Deletenews(id);

                    return RedirectToAction("../Administration/AllNews");
                }
            }

            return RedirectToAction("index", "home");
        }

        public ActionResult Deletecomment(int id)
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    DeleteComment(id);

                    return RedirectToAction("../Administration/AllComments");
                }
            }

            return RedirectToAction("index", "home");
        }

        public ActionResult DeleteUser(int id)
        {
            if (Session["Group_ID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    Deleteuser(id);
                    return RedirectToAction("../Administration/Allusers");
                }
            }

            return RedirectToAction("index", "home");
        }
    }
}