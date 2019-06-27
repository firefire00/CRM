using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Nezada.Common.Abp.Entity;
using Nezada.Common.Model;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    /// <summary>
    /// 收货人应用服务接口
    /// </summary>
    public interface IPptConsigneeAppService : IAsyncCrudAppService<Ppt_Consignee_AppOutputDto, string, Ppt_Consignee_AppGetAllInputDto, Ppt_Consignee_AppCreateInputDto, Ppt_Consignee_AppUpdateInputDto, Ppt_Consignee_AppGetInputDto, Ppt_Consignee_AppDeleteInputDto>
    {
        /// <summary>
        /// 新增收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<bool> CreatePptConsigneeAsync(Ppt_Consignee_AppCreateInputDto input);
        /// <summary>
        /// 查询收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<PaginatedList<Ppt_Consignee_AppOutputDto>> GetAllListAsync(Ppt_Consignee_AppGetAllInputDto input);
        /// <summary>
        /// 查询收货人（用于下拉）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<SelectedItem>> GetConsigneeSelectedItemListAsync(Ppt_Consignee_AppGetTreeInputDto input);
    }
}
