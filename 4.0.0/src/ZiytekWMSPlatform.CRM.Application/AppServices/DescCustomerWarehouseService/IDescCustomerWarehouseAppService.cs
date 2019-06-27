using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    /// <summary>
    /// 客户-仓库应用服务接口
    /// </summary>
    public interface IDescCustomerWarehouseAppService : IAsyncCrudAppService<Desc_Customer_Warehouse_AppOutputDto, string, Desc_Customer_Warehouse_AppGetAllInputDto, Desc_Customer_Warehouse_AppCreateInputDto, Desc_Customer_Warehouse_AppUpdateInputDto, Desc_Customer_Warehouse_AppGetInputDto, Desc_Customer_Warehouse_AppDeleteInputDto>
    {
        /// <summary>
        /// 新增客户-仓库
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<bool> CreateDescCustomerWarehouseAsync(Desc_Customer_Warehouse_AppCreateInputDto input);
        /// <summary>
        /// 查询客户-仓库
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<PaginatedList<Desc_Customer_Warehouse_AppOutputDto>> GetAllListAsync(Desc_Customer_Warehouse_AppGetAllInputDto input);
        /// <summary>
        /// 新增客户-仓库
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <param name="customerWarehouseList">客户-仓库关系列表</param>
        /// <returns></returns>
        Task<bool> CreateDescCustomerWarehouseAsync(string customerid, List<Desc_Customer_Warehouse_AppCreateInputDto> customerWarehouseList);
        /// <summary>
        /// 查询客户关联的所有仓库
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <param name="tenantId">租户Id</param>
        /// <returns></returns>
        Task<Customer_Warehouse_AppOutputDto> GetCustomerWarehouseAsync(string customerid, string tenantId);
        /// <summary>
        /// 删除客户关联的所有仓库
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <returns></returns>
        Task DeleteAsync(string customerid);
    }
}
