using System.Threading.Tasks;
using Abp.Application.Navigation;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;

namespace ZiytekWMSPlatform.CRM.Web.Views.Shared.Components.TopMenu
{
    /// <summary>
    /// 
    /// </summary>
    public class TopMenuViewComponent : ViewComponent
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IAbpSession _abpSession;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userNavigationManager"></param>
        /// <param name="abpSession"></param>
        public TopMenuViewComponent(
            IUserNavigationManager userNavigationManager,
            IAbpSession abpSession
            )
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activeMenu"></param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(string activeMenu = "")
        {
            var model = new TopMenuViewModel
            {
                MainMenu = await _userNavigationManager.GetMenuAsync("MainMenu", _abpSession.ToUserIdentifier()),
                ActiveMenuItemName = activeMenu
            };

            return View(model);
        }
    }
}
