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
        public ActionResult SignInValidation(string Email, string Password)
        {
            var data = SignInValidator(Email, Password);
            List<SignInModel> SignIn = new List<SignInModel>();


            foreach (var users in data)
            {
                SignIn.Add(new SignInModel
                {
                    FirstName = users.FirstName,
                    LastName = users.LastName
                });
            }
            if (data != null)
            {
                return RedirectToAction("_Layout", "Shared", new { name = SignIn });
            }
            else
            {
                return RedirectToAction("Contact", "Contact");
            }

        }
    }
}