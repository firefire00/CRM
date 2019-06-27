using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Nezada.Common.Abp.Entity;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.IRepositories
{
    /// <summary>
    /// 自定义客户-仓库仓储接口
    /// </summary>
    public interface IDescCustomerWarehouseRepository : IRepository<Desc_Customer_Warehouse, string>
    {
        /// <summary>
        /// 查询客户-仓库列表
        /// </summary>
        /// <param name="dto">条件参数json</param>
        /// <returns></returns>
        Task<PaginatedList<Desc_Customer_Warehouse_OutputDto>> GetDescCustomerWarehouseOutputListAsync(string dto);
        /// <summary>
        /// 新增客户-收货人
        /// </summary>
        /// <param name="dataEntityList">客户-收货人关系列表</param>
        /// <returns></returns>
        Task<bool> InsertAsync(List<Desc_Customer_Warehouse> dataEntityList);
    }
}
