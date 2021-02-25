using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static FlickClick_ClassLibary.BusinessLogic.UserProcess;
using static Flick_Click.Crypto;
using Flick_Click.Models;
using System.Web.Mvc;
using System.IO;

namespace Flick_Click.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignInValidation(UserModel model)
        {
            var data = SignInValidator(model.EmailAddress, Hash(model.Password));

            // Handles wrong username and password
            if (data != null && !data.Any())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Set session
                for (int i = 0; i < 1; i++)
                {
                    Session["userID"] = data[i].ID;
                    Session["firstName"] = data[i].FirstName;
                    Session["lastName"] = data[i].LastName;
                    Session["Group_ID"] = data[i].Group_ID;
                }
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            if (Session["userID"] != null)
            {
                Session.Clear();
                Session.Abandon();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: SignIn
        public ActionResult ViewUser(int id)
        {
            if (Session["userID"] != null)
            {
                if (Convert.ToInt32(Session["userID"].ToString()) == id)
                {
                    var data = LoadUser(id);
                    UserModel user = new UserModel();

                    foreach (var row in data)
                    {
                        user.ID = row.ID;
                        user.FirstName = row.FirstName;
                        user.LastName = row.LastName;
                        user.EmailAddress = row.Email;
                        user.TelefonNummer = row.TlfNr;
                        user.Group = row.Group;
                        user.Img = row.ProfilePicture;
                        user.Created = row.Created;
                    }

                    return View(user);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Edit User
        public ActionResult EditUser(int id)
        {
            if (Session["userID"] != null)
            {
                if (Convert.ToInt32(Session["userID"].ToString()) == id)
                {
                    var data = LoadUser(id);
                    UserModel user = new UserModel();

                    foreach (var row in data)
                    {
                        user.ID = row.ID;
                        user.FirstName = row.FirstName;
                        user.LastName = row.LastName;
                        user.EmailAddress = row.Email;
                        user.TelefonNummer = row.TlfNr;
                        user.Img = row.ProfilePicture;
                    }

                    return View(user);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(UserModel model)
        {
            if (Session["userID"] != null)
            {
                if (Convert.ToInt32(Session["userID"].ToString()) == model.ID)
                {
                    // Checks if there is an image uploaded
                    if (model.ImageFile != null)
                    {
                        // Get file name
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                        // Get file extension like jpg, gif etc.
                        string extension = Path.GetExtension(model.ImageFile.FileName);
                        // Set date on file name so no duplicates.
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        // Set path
                        model.Img = "/Content/Pictures/" + fileName;
                        fileName = Path.Combine(Server.MapPath("/Content/Pictures/"), fileName);
                        // Save image
                        model.ImageFile.SaveAs(fileName);
                    }

                    UpdateUser(model.ID, model.FirstName, model.LastName, model.EmailAddress, model.TelefonNummer, model.Img);
                    return RedirectToAction($"../SignIn/ViewUser/{model.ID}");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserComments(Nullable<int> id)
        {
            if (Session["userID"] != null)
            {
                if (Convert.ToInt32(Session["userID"].ToString()) == id)
                {
                    var data = LoadUsersComments(id);
                    List<UserCommetModel> commets = new List<UserCommetModel>();

                    foreach (var row in data)
                    {
                        commets.Add(new UserCommetModel
                        {
                            Title = row.Title,
                            Created = row.Created,
                            Content = row.Content
                        });

                    }
                    return View(commets);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}