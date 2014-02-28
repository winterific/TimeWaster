using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeWaster.Models;

namespace TimeWaster.ViewModels
{
    public class InfoConsole
    {
        public List<Session> PreviousSessions { get; set; }
        public TimeSpan GrandTotal { get; set; }
    }
}