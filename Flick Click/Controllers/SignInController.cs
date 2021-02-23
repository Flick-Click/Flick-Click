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
            List<SignedInModel> SignIn = new List<SignedInModel>();

            // Handles wrong username and password
            if (data != null && !data.Any())
            {
                model.LoginErrorMessage = "Wrong username or password";
                return View("SignIn", model);
            }
            else
            {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("Index", "Home");
        }
    }
}