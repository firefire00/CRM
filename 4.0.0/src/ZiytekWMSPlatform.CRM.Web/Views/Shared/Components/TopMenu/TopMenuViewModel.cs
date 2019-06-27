using Abp.Application.Navigation;
using ZiytekWMSPlatform.CRM.Web.Utils;

namespace ZiytekWMSPlatform.CRM.Web.Views.Shared.Components.TopMenu
{
    /// <summary>
    /// 
    /// </summary>
    public class TopMenuViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public UserMenu MainMenu { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ActiveMenuItemName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationPath"></param>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public string CalculateMenuUrl(string applicationPath, UserMenuItem menuItem)
        {
            if (string.IsNullOrEmpty(menuItem.Url))
            {
                return applicationPath;
            }

            if (UrlHelper.IsRooted(menuItem.Url))
            {
                return menuItem.Url;
            }

            return applicationPath + menuItem.Url;
        }
    }
}