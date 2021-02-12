using Flick_Click.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.ContactProcess;

namespace Flick_Click.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                CreateContact(model.Name, model.EmailAddress, model.Messege);
                return RedirectToAction("index", "Home");
            }

            return View();
        }
    }
}