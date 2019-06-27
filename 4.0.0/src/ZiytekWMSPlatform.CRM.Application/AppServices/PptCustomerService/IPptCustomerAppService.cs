using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Nezada.Common.Abp.Entity;
using Nezada.Common.Model;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    /// <summary>
    /// 客户应用服务接口
    /// </summary>
    public interface IPptCustomerAppService : IAsyncCrudAppService<Ppt_Customer_AppOutputDto, string, Ppt_Customer_AppGetAllInputDto, Ppt_Customer_AppCreateInputDto, Ppt_Customer_AppUpdateInputDto, Ppt_Customer_AppGetInputDto, Ppt_Customer_AppDeleteInputDto>
    {
        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<bool> CreatePptCustomerAsync(Ppt_Customer_AppCreateInputDto input);
        /// <summary>
        /// 查询客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<PaginatedList<Ppt_Customer_AppOutputDto>> GetAllListAsync(Ppt_Customer_AppGetAllInputDto input);
        /// <summary>
        /// 查询客户可选项列表
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<List<SelectedItem>> GetCustomerSelectedItemListAsync(Ppt_Customer_AppGetTreeInputDto input);
        /// <summary>
        /// 查询客户合作仓库所属物资列表
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<PaginatedList<Ppt_Customer_AppOutputDto>> GetCustomerWarehouseListAsync(Ppt_Customer_AppGetAllInputDto input);
    }
}
