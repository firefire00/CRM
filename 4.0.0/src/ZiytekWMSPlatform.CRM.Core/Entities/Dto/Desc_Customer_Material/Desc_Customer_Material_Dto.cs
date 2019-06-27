using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    #region 实体输入类
    /// <summary>
    /// 客户-物资实体输入类
    /// </summary>
    public class Desc_Customer_Material_InputDto : INezadaEntityInputDto<string>
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

    #region 实体输出类
    /// <summary>
    /// 客户-物资实体输出类
    /// </summary>
    public class Desc_Customer_Material_OutputDto : INezadaEntityOutputDto<string>
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
}
