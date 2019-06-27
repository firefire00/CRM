using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using Nezada.Common.Abp.Entity;
using Nezada.Common.Model;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    /// <summary>
    /// 客户-物资应用服务接口
    /// </summary>
    public interface IDescCustomerMaterialAppService : IAsyncCrudAppService<Desc_Customer_Material_AppOutputDto, string, Desc_Customer_Material_AppGetAllInputDto, Desc_Customer_Material_AppCreateInputDto, Desc_Customer_Material_AppUpdateInputDto, Desc_Customer_Material_AppGetInputDto, Desc_Customer_Material_AppDeleteInputDto>
    {
        /// <summary>
        /// 新增客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<bool> CreateDescCustomerMaterialAsync(Desc_Customer_Material_AppCreateInputDto input);
        /// <summary>
        /// 查询客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<PaginatedList<Desc_Customer_Material_AppOutputDto>> GetAllListAsync(Desc_Customer_Material_AppGetAllInputDto input);
        /// <summary>
        /// 导入客户物资关系
        /// </summary>
        /// <param name="stream">Excel文件路径</param>
        /// <param name="fileName">Excel文件名</param>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        Task<OutData_AppOutputDto> ImportCustomerMaterial(Stream stream, string fileName, Desc_Customer_Material_AppCreateInputDto input);
        /// <summary>
        /// 导出错误数据
        /// </summary>
        /// <param name="data">错误数据</param>
        /// <returns></returns>
        Task<Stream> ExportFailDataList(List<ExprotMaterialInfo> data);
        /// <summary>
        /// 保存维护客户物资
        /// </summary>
        /// <param name="data">成功数据</param>
        /// <returns></returns>
        Task<bool> InputCustomerMaterialAsync(List<SaveExcel_AppInputDto> data);
        /// <summary>
        /// 查询客户-物资选项列表（后端使用）
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="SelectedItem" langword="true">客户-物资列表</see>
        /// </returns>
        Task<List<SelectedItem>> GetAllCustomerMaterialAsync(Desc_Customer_Material_AppGetAllInputDto input);
    }
}
