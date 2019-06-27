using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Nezada.Common.Model;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    #region 客户-仓库BaseDto
    /// <summary>
    /// 客户-仓库BaseDto
    /// </summary>
    [AutoMap(typeof(Desc_Customer_Warehouse))]
    public class Desc_Customer_Warehouse_BaseDto
    {
        /// <summary>
        /// 客户Id（前端不传）
        /// </summary>
        public string Customerid { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public string Warehouseid { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Begintime { get; set; }
        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime? Endtime { get; set; }
        /// <summary>
        /// 长期有效
        /// </summary>
        public bool? Islongterm { get; set; }
    }
    #endregion

    #region 客户-仓库AppInputDto
    /// <summary>
    /// 客户-仓库AppInputDto
    /// </summary>
    public class Desc_Customer_Warehouse_AppInputDto : Desc_Customer_Warehouse_BaseDto
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

    #region 客户-仓库_新增AppCreateInputDto
    /// <summary>
    /// 客户-仓库_新增AppCreateInputDto
    /// </summary>
    public class Desc_Customer_Warehouse_AppCreateInputDto : Desc_Customer_Warehouse_AppInputDto
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

    #region 客户-仓库_修改AppUpdateInputDto
    /// <summary>
    /// 客户-仓库_修改AppUpdateInputDto
    /// </summary>
    public class Desc_Customer_Warehouse_AppUpdateInputDto : Desc_Customer_Warehouse_AppInputDto, IEntityDto<string>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Desc_Customer_Warehouse_AppUpdateInputDto()
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

    #region 客户-仓库_获取AppGetInputDto
    /// <summary>
    /// 客户-仓库_获取AppGetInputDto
    /// </summary>
    public class Desc_Customer_Warehouse_AppGetInputDto : IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
    }
    #endregion

    #region 客户-仓库_查询AppGetAllInputDto
    /// <summary>
    /// 客户-仓库_查询AppGetAllInputDto
    /// </summary>
    public class Desc_Customer_Warehouse_AppGetAllInputDto : Desc_Customer_Warehouse_BaseDto
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

    #region 客户-仓库_删除AppDeleteInputDto
    /// <summary>
    /// 客户-仓库_删除AppDeleteInputDto
    /// </summary>
    public class Desc_Customer_Warehouse_AppDeleteInputDto : IEntityDto<string>
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
        /// 仓库Id
        /// </summary>
        public string Warehouseid { get; set; }
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

    #region 客户-仓库_输出AppOutputDto
    /// <summary>
    /// 客户-仓库_输出AppOutputDto
    /// </summary>
    public class Desc_Customer_Warehouse_AppOutputDto : Desc_Customer_Warehouse_BaseDto, IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }
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

    /// <summary>
    /// 客户-仓库_输出AppOutputDto
    /// </summary>
    public class Customer_Warehouse_AppOutputDto
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Customer_Warehouse_AppOutputDto()
        {
            WarehouseList = new List<SelectedItem>();
            CustomerWarehouseList = new List<Desc_Customer_Warehouse_AppOutputDto>();
        }
        /// <summary>
        /// 合作仓库
        /// </summary>
        public List<SelectedItem> WarehouseList { get; set; }
        /// <summary>
        /// 合作时效
        /// </summary>
        public List<Desc_Customer_Warehouse_AppOutputDto> CustomerWarehouseList { get; set; }
    }
    #endregion
}
