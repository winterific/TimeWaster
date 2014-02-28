using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TimeWastedByEktron.Web.Models;
using TimeWastedByEktron.Web.ViewModels;

namespace TimeWastedByEktron.Web.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult Login()
        {
            var model = new UserLogin();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var user = Context.Users.FirstOrDefault(u => u.UserName == model.Username);

            }

            return View(model);
        }

        public ActionResult Register()
        {
            var model = new UserRegistration();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    DateCreated = DateTime.Now,
                    LastLoginDate = DateTime.Now
                };

                Context.Users.Add(user);
                Context.SaveChanges();

                // log in the user.
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
