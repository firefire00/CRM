using Abp.Application.Services;

namespace ZiytekWMSPlatform.CRM
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class CRMAppServiceBase : ApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        protected CRMAppServiceBase()
        {
            LocalizationSourceName = CRMConsts.LocalizationSourceName;
        }
    }
}