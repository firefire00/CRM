using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Nezada.Common.Abp.Entity;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.IRepositories
{
    /// <summary>
    /// 自定义客户仓储接口
    /// </summary>
    public interface IPptCustomerRepository : IRepository<Ppt_Customer, string>
    {
        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="dto">条件参数json</param>
        /// <returns></returns>
        Task<PaginatedList<Ppt_Customer_OutputDto>> GetPptCustomerOutputListAsync(string dto);
    }
}
