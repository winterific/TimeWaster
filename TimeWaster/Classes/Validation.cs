using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TimeWastedByEktron.Web.Classes
{
    public static class Validation
    {
        /// <summary>
        /// Pattern for a valid username.
        /// </summary>
        public static readonly Regex UsernamePattern = new Regex(@"^[a-z0-9]{3,12}$", RegexOptions.IgnoreCase);

        /// <summary>
        /// Pattern for a valid password.
        /// </summary>
        public static readonly Regex PasswordPattern = new Regex(@"^[\w\S]{6,20}$", RegexOptions.IgnoreCase);

        /// <summary>
        /// Pattern for a valid email address.
        /// </summary>
        public static readonly Regex EmailPattern;
        /// <summary>
        /// Pattern matching string to match a valid email address.
        /// </summary>
        /// <remarks>
        /// http://www.codeproject.com/Articles/22777/Email-Address-Validation-Using-Regular-Expression
        /// </remarks>
        private const string EmailPatternString = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        static Validation()
        {
            EmailPattern = new Regex(EmailPatternString, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Is this string a valid username?
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsValidUsername(this string username)
        {
            return !string.IsNullOrEmpty(username) && UsernamePattern.IsMatch(username);
        }

        /// <summary>
        /// Is this string a valid password?
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsValidPassword(this string password)
        {
            return !string.IsNullOrEmpty(password) && PasswordPattern.IsMatch(password);
        }

        /// <summary>
        /// Is this a valid email address?
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(this string email)
        {
            return !string.IsNullOrEmpty(email) && EmailPattern.IsMatch(email);
        }
    }
}