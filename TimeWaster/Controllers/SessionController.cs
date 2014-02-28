using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeWaster.Models;
using TimeWaster.ViewModels;

namespace TimeWaster.Controllers
{
    public class SessionController : BaseController
    {
        //
        // GET: /Session/

        [Authorize]
        public ActionResult Save(SaveSession model)
        {
            if (ModelState.IsValid && model.Duration.HasValue)
            {
                var session = Context.Sessions.FirstOrDefault(e => e.Uid == model.SessionId); //SessionModel.Mapper.Instance.Get(new SessionModel.QueryByIdentity(sessionId));
                session = session ?? new Session() { UserId = CurrentUser.Id }; //new SessionModel.Entity { UserId = user.Id.Value };
                session.Duration = new TimeSpan(0, 0, 0, 0, model.Duration.Value);

                // Save the session.
                Context.Sessions.Add(session);
                Context.SaveChanges();

                return Json(new { status = "success" });
            }

            return Json(new { status = "failure" });
        }

    }
}
