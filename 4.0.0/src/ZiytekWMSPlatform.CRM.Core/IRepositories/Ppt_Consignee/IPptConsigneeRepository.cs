using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Nezada.Common.Abp.Entity;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.IRepositories
{
    /// <summary>
    /// 自定义收货人仓储接口
    /// </summary>
    public interface IPptConsigneeRepository : IRepository<Ppt_Consignee, string>
    {
        /// <summary>
        /// 查询收货人列表
        /// </summary>
        /// <param name="dto">条件参数json</param>
        /// <returns></returns>
        Task<PaginatedList<Ppt_Consignee_OutputDto>> GetPptConsigneeOutputListAsync(string dto);
    }
}
