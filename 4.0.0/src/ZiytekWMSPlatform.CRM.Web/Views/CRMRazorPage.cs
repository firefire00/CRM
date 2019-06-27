using Abp.AspNetCore.Mvc.Views;

namespace ZiytekWMSPlatform.CRM.Web.Views
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class CRMRazorPage<TModel> : AbpRazorPage<TModel>
    {
        /// <summary>
        /// 
        /// </summary>
        protected CRMRazorPage()
        {
            LocalizationSourceName = CRMConsts.LocalizationSourceName;
        }
    }
}
