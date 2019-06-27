using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Nezada.Common.Abp.Entity;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.IRepositories
{
    /// <summary>
    /// 自定义客户-物资仓储接口
    /// </summary>
    public interface IDescCustomerMaterialRepository : IRepository<Desc_Customer_Material, string>
    {
        /// <summary>
        /// 查询客户-物资列表
        /// </summary>
        /// <param name="dto">条件参数json</param>
        /// <returns></returns>
        Task<PaginatedList<Desc_Customer_Material_OutputDto>> GetDescCustomerMaterialOutputListAsync(string dto);
        /// <summary>
        /// 批量保存客户物资关系
        /// </summary>
        /// <param name="desc_Customer_MaterialList"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(List<Desc_Customer_Material> desc_Customer_MaterialList);
    }
}
