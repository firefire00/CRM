using System.Threading.Tasks;
using Abp.Domain.Services;
using ZiytekWMSPlatform.CRM.AppServices;

namespace ZiytekWMSPlatform.CRM.DomainServices
{
    /// <summary>
    /// 客户领域服务接口
    /// </summary>
    public interface IPptCustomerManager : IDomainService
    {
        /// <summary>
        /// 新增验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<string> CreateValidateAsync(Ppt_Customer_AppCreateInputDto input);
        /// <summary>
        /// 修改验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<string> UpdateValidateAsync(Ppt_Customer_AppUpdateInputDto input);
    }
}
