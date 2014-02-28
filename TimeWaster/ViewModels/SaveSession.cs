using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeWastedByEktron.Web.ViewModels
{
    /// <summary>
    /// Save a session to a session ID.
    /// </summary>
    public class SaveSession
    {
        [Required]
        public Guid? SessionId { get; set; }

        [Required]
        public int? Duration { get; set; }

    }
}