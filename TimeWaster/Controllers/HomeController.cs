using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeWastedByEktron.Web.ViewModels;

namespace TimeWastedByEktron.Web.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new HomePage();

            if (CurrentUser != null)
            {
                model.CurrentUser = CurrentUser;
                var previousSessions = Context.Sessions
                    .Where(f => f.UserId == CurrentUser.Id)
                    .OrderByDescending(f => f.SessionDate)
                    .ToList();
                var total = previousSessions.Sum(f => f.Duration.TotalSeconds);
                model.InfoConsole = new InfoConsole()
                {
                    PreviousSessions = previousSessions,
                    GrandTotal = new TimeSpan(0, 0, (int)total)
                };
            }

            return View(model);
        }

    }
}
