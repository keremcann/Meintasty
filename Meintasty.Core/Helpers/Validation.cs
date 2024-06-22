using System.Text.RegularExpressions;

namespace Meintasty.Core.Helpers
{
    public static class Validation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ChechEmail(this string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
