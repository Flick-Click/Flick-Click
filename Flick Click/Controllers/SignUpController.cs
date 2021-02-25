using Flick_Click.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.UserProcess;
using static Flick_Click.Crypto;

namespace Flick_Click.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult SignUp()
        {
            UserModel user = new UserModel();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserModel model)
        {
            var data = LoadUsersEmail();
            bool Exists = false;

            foreach (var Email in data)
            {
                if (Email.Email == model.EmailAddress)
                {
                    Exists = true;
                }
            }

            if (!Exists)
            {
                // Checks if there is an image uploaded
                if (model.ImageFile != null)
                {
                    // Get file name
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    // Get file extension like jpg, gif etc.
                    string extension = Path.GetExtension(model.ImageFile.FileName);

                    // Checks if file is actually an image and not a file that is a danger.
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".gif" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                    {
                        // Set date on file name so no duplicates.
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        // Set path
                        model.Img = "/Content/Pictures/" + fileName;
                        fileName = Path.Combine(Server.MapPath("/Content/Pictures/"), fileName);
                        // Save image
                        model.ImageFile.SaveAs(fileName);
                    }
                    else
                    {
                        model.FileErrorMessage = "File uploaded was not a jpg, png, jpeg or gif";
                        return View(model);
                    }
                }
                else
                {
                    model.Img = "/Content/Pictures/UserDefault.png";
                }

                // Hash Password
                model.Password = Hash(model.Password);
                model.ConfirmPassword = Hash(model.ConfirmPassword);

                CreateUser(model.FirstName, model.LastName, model.Password, model.EmailAddress, model.TelefonNummer, model.Img);
                return RedirectToAction("../Home/Index");
            }
            return View();
        }
    }
}