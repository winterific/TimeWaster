﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeWastedByEktron.Web.ViewModels
{
    public class UserLogin
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}