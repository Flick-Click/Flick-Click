using Flick_Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.UserProcess;

namespace Flick_Click.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserModel model)
        {
            CreateUser(model.FistName, model.LastName, model.Password, model.EmailAddress, model.TelefonNummer);
            return RedirectToAction("../Home/Index");
        }
    }
}