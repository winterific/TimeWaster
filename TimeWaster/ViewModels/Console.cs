using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeWastedByEktron.Web.Models;

namespace TimeWastedByEktron.Web.ViewModels
{
    public class InfoConsole
    {
        public List<Session> PreviousSessions { get; set; }
        public TimeSpan GrandTotal { get; set; }
    }
}