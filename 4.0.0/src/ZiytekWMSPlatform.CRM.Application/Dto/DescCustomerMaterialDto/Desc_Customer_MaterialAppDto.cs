using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    #region 客户-物资BaseDto
    /// <summary>
    /// 客户-物资BaseDto
    /// </summary>
    [AutoMap(typeof(Desc_Customer_Material))]
    public class Desc_Customer_Material_BaseDto
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public string Customerid { get; set; }
        /// <summary>
        /// 物资Id
        /// </summary>
        public string Materialid { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public string Warehouseid { get; set; }
    }
    #endregion

    #region 客户-物资AppInputDto
    /// <summary>
    /// 客户-物资AppInputDto
    /// </summary>
    public class Desc_Customer_Material_AppInputDto : Desc_Customer_Material_BaseDto
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

    #region 客户-物资_新增AppCreateInputDto
    /// <summary>
    /// 客户-物资_新增AppCreateInputDto
    /// </summary>
    public class Desc_Customer_Material_AppCreateInputDto : Desc_Customer_Material_AppInputDto
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

    #region 客户-物资_修改AppUpdateInputDto
    /// <summary>
    /// 客户-物资_修改AppUpdateInputDto
    /// </summary>
    public class Desc_Customer_Material_AppUpdateInputDto : Desc_Customer_Material_AppInputDto, IEntityDto<string>
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Desc_Customer_Material_AppUpdateInputDto()
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

    #region 客户-物资_获取AppGetInputDto
    /// <summary>
    /// 客户-物资_获取AppGetInputDto
    /// </summary>
    public class Desc_Customer_Material_AppGetInputDto : IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
    }
    #endregion

    #region 客户-物资_查询AppGetAllInputDto
    /// <summary>
    /// 客户-物资_查询AppGetAllInputDto
    /// </summary>
    public class Desc_Customer_Material_AppGetAllInputDto : Desc_Customer_Material_BaseDto
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

    #region 客户-物资_删除AppDeleteInputDto
    /// <summary>
    /// 客户-物资_删除AppDeleteInputDto
    /// </summary>
    public class Desc_Customer_Material_AppDeleteInputDto : IEntityDto<string>
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
    }
    #endregion

    #region 客户-物资_输出AppOutputDto
    /// <summary>
    /// 客户-物资_输出AppOutputDto
    /// </summary>
    public class Desc_Customer_Material_AppOutputDto : Desc_Customer_Material_BaseDto, IEntityDto<string>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 物资名称
        /// </summary>
        public string Materialname { get; set; }
        /// <summary>
        /// SKU编码
        /// </summary>
        public string Skuid { get; set; }
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

    #region 获取物资信息
    /// <summary>
    /// 获取物资信息
    /// </summary>
    public class MaterialInfo
    {
        /// <summary>
        /// 物资Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 物资名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// SKU编码
        /// </summary>
        public string Skuid { get; set; }
    }
    #endregion

    #region 导出物资信息
    /// <summary>
    /// 导出物资信息
    /// </summary>
    public class ExprotMaterialInfo
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        [DisplayName("错误信息")]
        public string ErrorMse { get; set; }
        /// <summary>
        /// 物资名称
        /// </summary>
        [DisplayName("物资名称")]
        public string Materialname { get; set; }
        /// <summary>
        /// SKU编码
        /// </summary>
        [DisplayName("SKU编码")]
        public string Skuid { get; set; }
    }
    #endregion

    #region 表数据验证_输出AppOutputDto
    /// <summary>
    /// 表数据验证_输出AppOutputDto
    /// </summary>
    public class OutData_AppOutputDto
    {
        /// <summary>
        /// 失败表
        /// </summary>
        public DataTable ErrorTable { get; set; }
        /// <summary>
        /// 成功表
        /// </summary>
        public DataTable SuccessData { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int AllCount { get; set; }
        /// <summary>
        /// 成功条数
        /// </summary>
        public int SuccessCount { get; set; }
        /// <summary>
        /// 失败条数
        /// </summary>
        public int FailCount { get; set; }
    }
    #endregion

    #region 保存维护客户物资_输入SaveExcel_AppInputDto
    /// <summary>
    /// 保存维护客户物资_输入SaveExcel_AppInputDto
    /// </summary>
    public class SaveExcel_AppInputDto
    {
        /// <summary>
        /// 物资ID
        /// </summary>
        public string Materialid { get; set; }
        /// <summary>
        /// 物资名称
        /// </summary>
        public string Materialname { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public string Customerid { get; set; }
        /// <summary>
        /// 操作人Id
        /// </summary>
        public string OperaterUserId { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public string Warehouseid { get; set; }
    }
    #endregion
}
