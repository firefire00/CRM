using Abp.AspNetCore.Mvc.Controllers;

namespace ZiytekWMSPlatform.CRM.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CRMControllerBase : AbpController
    {
        /// <summary>
        /// 
        /// </summary>
        protected CRMControllerBase()
        {
            LocalizationSourceName = CRMConsts.LocalizationSourceName;
        }
    }
}