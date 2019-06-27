using System.Threading.Tasks;
using BeetleX.FastHttpApi;
using BeetleX.FastHttpApi.Clients;
using Nezada.Common.Model;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    #region 用户接口
    /// <summary>
    /// 用户接口
    /// </summary>
    [JsonFormater]
    [Controller(BaseUrl = "PptUser")]
    public interface IUserInterface
    {
        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="tenantId">租户Id</param>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        Task<NezadaJsonDto> GetAllUserList(string tenantId, int pageNo = 0, int pageSize = 0);
    }
    #endregion

    #region 行政区域接口
    /// <summary>
    /// 行政区域接口
    /// </summary>
    [JsonFormater]
    [Controller(BaseUrl = "BaArea")]
    public interface IAddressInterface
    {
        /// <summary>
        /// 查询所有省市区列表
        /// </summary>
        /// <param name="provinceid">省份Id</param>
        /// <param name="cityid">城市Id</param>
        /// <param name="areaid">地区Id</param>
        /// <returns>
        /// <see cref="SelectedItem" langword="true">下拉项</see>
        /// </returns>
        Task<NezadaJsonDto> GetAllAddressList(int? provinceid, int? cityid, int? areaid);
    }
    #endregion

    #region 仓库设施接口
    /// <summary>
    /// 仓库设施接口
    /// </summary>
    [JsonFormater]
    [Controller(BaseUrl = "PptWarehouse")]
    public interface IFacilitiesInterface
    {
        /// <summary>
        /// 查询可选择的仓库列表
        /// </summary>
        /// <param name="tenantid">租户Id</param>
        /// <param name="isactive">是否可用</param>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <returns>
        /// <see cref="SelectedItem" langword="true">下拉项</see>
        /// </returns>
        Task<NezadaJsonDto> GetWarehouseSelectedItemList(string tenantid, bool? isactive, int pageNo = 0, int pageSize = 0);
    }
    #endregion

    #region 物资
    /// <summary>
    /// 物资接口
    /// </summary>
    [JsonFormater]
    [Controller(BaseUrl = "PptMaterial")]
    public interface IMaterialInterface
    {
        /// <summary>
        /// 查询物资
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<NezadaJsonDto> GetMaterial(string id);
        /// <summary>
        /// 查询物资列表
        /// </summary>
        /// <param name="tenantId">租户id</param>
        /// <param name="warehouseid">仓库id</param>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        Task<NezadaJsonDto> GetAllPptMaterial(string tenantId, string warehouseid, int pageNo = 0, int pageSize = 0);
    }
    #endregion

}
