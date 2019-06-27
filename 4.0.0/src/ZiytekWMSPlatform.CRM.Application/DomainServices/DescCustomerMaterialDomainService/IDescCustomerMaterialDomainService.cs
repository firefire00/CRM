using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Abp.Domain.Services;
using ZiytekWMSPlatform.CRM.AppServices;

namespace ZiytekWMSPlatform.CRM.DomainServices
{
    /// <summary>
    /// 客户-物资领域服务接口
    /// </summary>
    public interface IDescCustomerMaterialManager : IDomainService
    {
        /// <summary>
        /// 新增验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<string> CreateValidateAsync(Desc_Customer_Material_AppCreateInputDto input);
        /// <summary>
        /// 修改验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<string> UpdateValidateAsync(Desc_Customer_Material_AppUpdateInputDto input);
        /// <summary>
        /// 客户物资导入验证
        /// </summary>
        /// <param name="input"></param>
        /// <param name="dataTable"></param>
        /// <param name="errorTable"></param>
        /// <param name="successData"></param>
        /// <param name="materialInfoList"></param>
        /// <returns></returns>
        Task<string> ImportValidateAsync(Desc_Customer_Material_AppCreateInputDto input, DataTable dataTable, DataTable errorTable, DataTable successData, List<MaterialInfo> materialInfoList);
        /// <summary>
        /// Excel数据列名验证
        /// </summary>
        /// <param name="dt">Excel数据</param>
        Task TemplateValidateAsync(DataTable dt);
    }
}
