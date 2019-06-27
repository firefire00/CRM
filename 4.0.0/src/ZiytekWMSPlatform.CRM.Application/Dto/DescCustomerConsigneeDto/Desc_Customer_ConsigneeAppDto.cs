using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    #region 客户-收货人BaseDto
    /// <summary>
    /// 客户-收货人BaseDto
    /// </summary>
    [AutoMap(typeof(Desc_Customer_Consignee))]
    public class Desc_Customer_Consignee_BaseDto
    {
        /// <summary>
        /// 客户Id（前端不传）
        /// </summary>
        public string Customerid { get; set; }
        /// <summary>
        /// 收货人Id
        /// </summary>
        public string Consigneeid { get; set; }
    }
    #endregion

    #region 客户-收货人AppInputDto
    /// <summary>
    /// 客户-收货人AppInputDto
    /// </summary>
    public class Desc_Customer_Consignee_AppInputDto : Desc_Customer_Consignee_BaseDto
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

    #region 客户-收货人_新增AppCreateInputDto
    /// <summary>
    /// 客户-收货人_新增AppCreateInputDto
    /// </summary>
    public class Desc_Customer_Consignee_AppCreateInputDto : Desc_Customer_Consignee_AppInputDto
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

    #region 客户-收货人_修改AppUpdateInputDto
    /// <summary>
    /// 客户-收货人_修改AppUpdateInputDto
    /// </summary>
    public class Desc_Customer_Consignee_AppUpdateInputDto : Desc_Customer_Consignee_AppInputDto, IEntityDto<string>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Desc_Customer_Consignee_AppUpdateInputDto()
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

    #region 客户-收货人_获取AppGetInputDto
    /// <summary>
    /// 客户-收货人_获取AppGetInputDto
    /// </summary>
    public class Desc_Customer_Consignee_AppGetInputDto : IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
    }
    #endregion

    #region 客户-收货人_查询AppGetAllInputDto
    /// <summary>
    /// 客户-收货人_查询AppGetAllInputDto
    /// </summary>
    public class Desc_Customer_Consignee_AppGetAllInputDto : Desc_Customer_Consignee_BaseDto
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
    #endregion

    #region 客户-收货人_删除AppDeleteInputDto
    /// <summary>
    /// 客户-收货人_删除AppDeleteInputDto
    /// </summary>
    public class Desc_Customer_Consignee_AppDeleteInputDto : IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public string Customerid { get; set; }
        /// <summary>
        /// 收货人Id
        /// </summary>
        public string Consigneeid { get; set; }
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

    #region 客户-收货人_输出AppOutputDto
    /// <summary>
    /// 客户-收货人_输出AppOutputDto
    /// </summary>
    public class Desc_Customer_Consignee_AppOutputDto : Desc_Customer_Consignee_BaseDto, IEntityDto<string>
    {
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
    }
    #endregion
}
