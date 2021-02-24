using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static FlickClick_ClassLibary.BusinessLogic.UserProcess;
using Flick_Click.Models;
using System.Web.Mvc;


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
            var data = SignInValidator(model.EmailAddress, model.Password);

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
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        // GET: SignIn
        public ActionResult ViewUser(int id)
        {
            var data = LoadUser(id);
            UserModel user = new UserModel();

            foreach (var row in data)
            {
                user.ID = row.ID;
                user.FirstName = row.FirstName;
                user.LastName = row.LastName;
                user.EmailAddress = row.Email;
                user.Group = row.Group;
                user.Img = row.ProfilePicture;
                user.Created = row.Created;
            }

            return View(user);
        }
    }
}