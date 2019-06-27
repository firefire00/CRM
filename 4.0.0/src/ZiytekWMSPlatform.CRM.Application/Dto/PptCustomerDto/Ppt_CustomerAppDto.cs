using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Nezada.Common.Model;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    #region 客户BaseDto
    /// <summary>
    /// 客户BaseDto
    /// </summary>
    [AutoMap(typeof(Ppt_Customer))]
    public class Ppt_Customer_BaseDto
    {
        /// <summary>
        /// 仓库Id
        /// </summary>
        public string Warehouseid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// 是否属于个人 true个人 false单位
        /// </summary>
        public bool? Ispersonal { get; set; }
        /// <summary>
        /// 客户类型（该字段应该传入 1供应商 2货主 3代销商 4经销商 5分包商）
        /// </summary>
        public int? Customertype { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Postcode { get; set; }
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
        public int? District { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 可用
        /// </summary>
        public bool? Isactive { get; set; }
    }
    #endregion

    #region 客户AppInputDto
    /// <summary>
    /// 客户AppInputDto
    /// </summary>
    public class Ppt_Customer_AppInputDto : Ppt_Customer_BaseDto
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Ppt_Customer_AppInputDto()
        {
            CustomerConsigneeList = new List<Desc_Customer_Consignee_AppCreateInputDto>();
            CustomerWarehouseList = new List<Desc_Customer_Warehouse_AppCreateInputDto>();
        }
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
        /// <summary>
        /// 客户-收货人关系列表
        /// </summary>
        public List<Desc_Customer_Consignee_AppCreateInputDto> CustomerConsigneeList { get; set; }
        /// <summary>
        /// 客户-仓库关系列表
        /// </summary>
        public List<Desc_Customer_Warehouse_AppCreateInputDto> CustomerWarehouseList { get; set; }
    }
    #endregion

    #region 客户_新增AppCreateInputDto
    /// <summary>
    /// 客户_新增AppCreateInputDto
    /// </summary>
    public class Ppt_Customer_AppCreateInputDto : Ppt_Customer_AppInputDto
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

    #region 客户_修改AppUpdateInputDto
    /// <summary>
    /// 客户_修改AppUpdateInputDto
    /// </summary>
    public class Ppt_Customer_AppUpdateInputDto : Ppt_Customer_AppInputDto, IEntityDto<string>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Ppt_Customer_AppUpdateInputDto()
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

    #region 客户_获取AppGetInputDto
    /// <summary>
    /// 客户_获取AppGetInputDto
    /// </summary>
    public class Ppt_Customer_AppGetInputDto : IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
    }
    #endregion

    #region 客户_查询AppGetAllInputDto
    /// <summary>
    /// 客户_查询AppGetAllInputDto
    /// </summary>
    public class Ppt_Customer_AppGetAllInputDto : Ppt_Customer_BaseDto
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
        /// <summary>
        /// 所有者Id
        /// </summary>
        public string CreatorUserId { get; set; }
    }

    /// <summary>
    /// 客户_查询AppGetTreeInputDto
    /// </summary>
    public class Ppt_Customer_AppGetTreeInputDto : Ppt_Customer_AppGetAllInputDto
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public string Id { get; set; }
    }
    #endregion

    #region 客户_删除AppDeleteInputDto
    /// <summary>
    /// 客户_删除AppDeleteInputDto
    /// </summary>
    public class Ppt_Customer_AppDeleteInputDto : IEntityDto<string>
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
        /// 租户Id
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// 微应用
        /// </summary>
        public string Systemtype { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public string Warehouseid { get; set; }
    }
    #endregion

    #region 客户_输出AppOutputDto
    /// <summary>
    /// 客户_输出AppOutputDto
    /// </summary>
    public class Ppt_Customer_AppOutputDto : Ppt_Customer_BaseDto, IEntityDto<string>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Ppt_Customer_AppOutputDto()
        {
            SexList = ConsigneeList = new List<SelectedItem>();
            CustomerWarehouse = new Customer_Warehouse_AppOutputDto();
            AllAddress = new NezadaAddress();
        }
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 合作仓库集合
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
        /// <summary>
        /// 性别列表
        /// </summary>
        public List<SelectedItem> SexList { get; set; }
        /// <summary>
        /// 客户-收货人列表
        /// </summary>
        public List<SelectedItem> ConsigneeList { get; set; }
        /// <summary>
        /// 客户-仓库关系
        /// </summary>
        public Customer_Warehouse_AppOutputDto CustomerWarehouse { get; set; }
        /// <summary>
        /// 所有的省市区列表
        /// </summary>
        public NezadaAddress AllAddress { get; set; }
    }
    #endregion
}
