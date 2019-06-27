using System.Threading.Tasks;
using Abp.Localization;
using Microsoft.AspNetCore.Mvc;

namespace ZiytekWMSPlatform.CRM.Web.Views.Shared.Components.LanguageSelection
{
    /// <summary>
    /// 
    /// </summary>
    public class LanguageSelectionViewComponent : ViewComponent
    {
        private readonly ILanguageManager _languageManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="languageManager"></param>
        public LanguageSelectionViewComponent(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.Yield();

            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _languageManager.CurrentLanguage,
                Languages = _languageManager.GetLanguages(),
                CurrentUrl = Request.Path
            };

            return View(model);
        }
    }
}
