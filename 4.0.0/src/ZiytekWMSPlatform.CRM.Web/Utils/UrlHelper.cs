using System.Text.RegularExpressions;

namespace ZiytekWMSPlatform.CRM.Web.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class UrlHelper
    {
        private static readonly Regex UrlWithProtocolRegex = new Regex("^.{1,10}://.*$");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsRooted(string url)
        {
            if (url.StartsWith("/"))
            {
                return true;
            }

            if (UrlWithProtocolRegex.IsMatch(url))
            {
                return true;
            }

            return false;
        }
    }
}