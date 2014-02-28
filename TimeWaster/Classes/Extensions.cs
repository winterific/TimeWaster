using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using TimeWaster.Models;

namespace TimeWaster
{
    public static class Extensions
    {
        /// <summary>
        /// Hash a password string.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(this string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);

            var hash = SHA256Managed.Create();
            var hashedBytes = hash.ComputeHash(bytes);

            return Convert.ToBase64String(hashedBytes);
        }

        /// <summary>
        /// Format a timespan consistently across the site.
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public static string StandardFormat(this TimeSpan span)
        {
            return span.ToString(@"hh\:mm\:ss\.fff");
        }

        /// <summary>
        /// Get a grand total of the durations in a set of sessions.
        /// </summary>
        /// <param name="sessions"></param>
        /// <returns></returns>
        public static TimeSpan GrandDurationTotal(this IEnumerable<Session> sessions)
        {
            if (sessions == null)
                return new TimeSpan(0);

            int grandTotal;
            var total = sessions.Sum(s => s.Duration.TotalMilliseconds);
            int.TryParse(total.ToString(), out grandTotal);

            return new TimeSpan(0, 0, 0, 0, grandTotal);
        }
    }
}