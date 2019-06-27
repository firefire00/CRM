using System.Threading.Tasks;
using Abp.Domain.Services;
using ZiytekWMSPlatform.CRM.AppServices;

namespace ZiytekWMSPlatform.CRM.DomainServices
{
    /// <summary>
    /// 收货人领域服务接口
    /// </summary>
    public interface IPptConsigneeManager : IDomainService
    {
        /// <summary>
        /// 新增验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<string> CreateValidateAsync(Ppt_Consignee_AppCreateInputDto input);
        /// <summary>
        /// 修改验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<string> UpdateValidateAsync(Ppt_Consignee_AppUpdateInputDto input);
    }
}
