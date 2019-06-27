using System.Collections.Generic;
using Abp.Localization;
using Microsoft.AspNetCore.Http;

namespace ZiytekWMSPlatform.CRM.Web.Views.Shared.Components.LanguageSelection
{
    /// <summary>
    /// 
    /// </summary>
    public class LanguageSelectionViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LanguageInfo CurrentLanguage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PathString CurrentUrl { get; set; }
    }
}