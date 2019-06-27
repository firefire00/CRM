using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    #region 实体输入类
    /// <summary>
    /// 客户-仓库实体输入类
    /// </summary>
    public class Desc_Customer_Warehouse_InputDto : INezadaEntityInputDto<string>
    {
        /// <summary>
        /// 客户Id
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

    #region 实体输出类
    /// <summary>
    /// 客户-仓库实体输出类
    /// </summary>
    public class Desc_Customer_Warehouse_OutputDto : INezadaEntityOutputDto<string>
    {
        /// <summary>
        /// 客户Id
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
}
