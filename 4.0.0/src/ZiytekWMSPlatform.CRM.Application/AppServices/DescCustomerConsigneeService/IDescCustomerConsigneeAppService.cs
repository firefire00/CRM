using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Nezada.Common.Abp.Entity;
using Nezada.Common.Model;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    /// <summary>
    /// 客户-收货人应用服务接口
    /// </summary>
    public interface IDescCustomerConsigneeAppService : IAsyncCrudAppService<Desc_Customer_Consignee_AppOutputDto, string, Desc_Customer_Consignee_AppGetAllInputDto, Desc_Customer_Consignee_AppCreateInputDto, Desc_Customer_Consignee_AppUpdateInputDto, Desc_Customer_Consignee_AppGetInputDto, Desc_Customer_Consignee_AppDeleteInputDto>
    {
        /// <summary>
        /// 新增客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<bool> CreateDescCustomerConsigneeAsync(Desc_Customer_Consignee_AppCreateInputDto input);
        /// <summary>
        /// 查询客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<PaginatedList<Desc_Customer_Consignee_AppOutputDto>> GetAllListAsync(Desc_Customer_Consignee_AppGetAllInputDto input);
        /// <summary>
        /// 新增客户-收货人
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <param name="customerConsigneeList">客户-收货人关系列表</param>
        /// <returns></returns>
        Task<bool> CreateDescCustomerConsigneeAsync(string customerid, List<Desc_Customer_Consignee_AppCreateInputDto> customerConsigneeList);
        /// <summary>
        /// 查询客户关联的所有收货人
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <param name="warehouseid">仓库Id</param>
        /// <returns></returns>
        Task<List<SelectedItem>> GetCustomerConsigneeAsync(string customerid, string warehouseid);
        /// <summary>
        /// 删除客户关联的所有收货人
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <returns></returns>
        Task DeleteAsync(string customerid);
    }
}
