using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeWaster.Models;

namespace TimeWaster.ViewModels
{
    public class HomePage
    {
        public TimeSpan CurrentDuration { get; set; }

        public User CurrentUser { get; set; }

        public InfoConsole InfoConsole { get; set; }
    }
}