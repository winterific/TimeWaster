using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TimeWaster.Models;

namespace TimeWaster.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ModelContext Context = new ModelContext();

        protected virtual User CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    return Context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                }
                return null;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.CurrentUser = CurrentUser;
        }
    }
}
