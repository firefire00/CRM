using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Nezada.Common.Model;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    #region 收货人BaseDto
    /// <summary>
    /// 收货人BaseDto
    /// </summary>
    [AutoMap(typeof(Ppt_Consignee))]
    public class Ppt_Consignee_BaseDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Consigneename { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobilephone { get; set; }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string Receivingunit { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public string Warehouseid { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public int? Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public int? City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public int? Area { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Provincetext { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string Citytext { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Areatext { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Detailaddress { get; set; }
    }
    #endregion

    #region 收货人AppInputDto
    /// <summary>
    /// 收货人AppInputDto
    /// </summary>
    public class Ppt_Consignee_AppInputDto : Ppt_Consignee_BaseDto
    {
        /// <summary>
        /// 操作人Id
        /// </summary>
        public string OperaterUserId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperaterUserName { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// 微应用
        /// </summary>
        public string Systemtype { get; set; }
    }
    #endregion

    #region 收货人_新增AppCreateInputDto
    /// <summary>
    /// 收货人_新增AppCreateInputDto
    /// </summary>
    public class Ppt_Consignee_AppCreateInputDto : Ppt_Consignee_AppInputDto
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
    }
    #endregion

    #region 收货人_修改AppUpdateInputDto
    /// <summary>
    /// 收货人_修改AppUpdateInputDto
    /// </summary>
    public class Ppt_Consignee_AppUpdateInputDto : Ppt_Consignee_AppInputDto, IEntityDto<string>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Ppt_Consignee_AppUpdateInputDto()
        {
            if (LastModificationTime == null)
            {
                LastModificationTime = DateTime.Now;
            }
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LastModificationTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改人Id
        /// </summary>
        public string LastModifierUserId { get; set; }
    }
    #endregion

    #region 收货人_获取AppGetInputDto
    /// <summary>
    /// 收货人_获取AppGetInputDto
    /// </summary>
    public class Ppt_Consignee_AppGetInputDto : IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
    }
    #endregion

    #region 收货人_查询AppGetAllInputDto
    /// <summary>
    /// 收货人_查询AppGetAllInputDto
    /// </summary>
    public class Ppt_Consignee_AppGetAllInputDto : Ppt_Consignee_BaseDto
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNo { get; set; } = 1;
        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// 操作人Id
        /// </summary>
        public string OperaterUserId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperaterUserName { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// 微应用
        /// </summary>
        public string Systemtype { get; set; }
    }

    /// <summary>
    /// 项目_查询AppGetTreeInputDto
    /// </summary>
    public class Ppt_Consignee_AppGetTreeInputDto : Ppt_Consignee_AppGetAllInputDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
    }
    #endregion

    #region 收货人_删除AppDeleteInputDto
    /// <summary>
    /// 收货人_删除AppDeleteInputDto
    /// </summary>
    public class Ppt_Consignee_AppDeleteInputDto : IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 操作人Id
        /// </summary>
        public string OperaterUserId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperaterUserName { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public string WarehouseId { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// 微应用
        /// </summary>
        public string Systemtype { get; set; }
    }
    #endregion

    #region 收货人_输出AppOutputDto
    /// <summary>
    /// 收货人_输出AppOutputDto
    /// </summary>
    public class Ppt_Consignee_AppOutputDto : Ppt_Consignee_BaseDto, IEntityDto<string>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Ppt_Consignee_AppOutputDto()
        {
            AllAddress = new NezadaAddress();
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LastModificationTime { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 修改人Id
        /// </summary>
        public string LastModifierUserId { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 所有的省市区列表
        /// </summary>
        public NezadaAddress AllAddress { get; set; }
    }
    #endregion
}
