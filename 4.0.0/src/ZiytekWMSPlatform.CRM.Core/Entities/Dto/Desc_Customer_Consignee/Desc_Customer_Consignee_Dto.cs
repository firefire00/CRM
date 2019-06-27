using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    #region 实体输入类
    /// <summary>
    /// 客户-收货人实体输入类
    /// </summary>
    public class Desc_Customer_Consignee_InputDto : INezadaEntityInputDto<string>
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public string Customerid { get; set; }
        /// <summary>
        /// 收货人Id
        /// </summary>
        public string Consigneeid { get; set; }
    }
    #endregion

    #region 实体输出类
    /// <summary>
    /// 客户-收货人实体输出类
    /// </summary>
    public class Desc_Customer_Consignee_OutputDto : INezadaEntityOutputDto<string>
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public string Customerid { get; set; }
        /// <summary>
        /// 收货人Id
        /// </summary>
        public string Consigneeid { get; set; }
    }
    #endregion
}
