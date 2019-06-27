using System.Threading.Tasks;
using Abp.Domain.Services;
using ZiytekWMSPlatform.CRM.AppServices;

namespace ZiytekWMSPlatform.CRM.DomainServices
{
    /// <summary>
    /// 客户-仓库领域服务接口
    /// </summary>
    public interface IDescCustomerWarehouseManager : IDomainService
    {
        /// <summary>
        /// 新增验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<string> CreateValidateAsync(Desc_Customer_Warehouse_AppCreateInputDto input);
        /// <summary>
        /// 修改验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<string> UpdateValidateAsync(Desc_Customer_Warehouse_AppUpdateInputDto input);
    }
}
