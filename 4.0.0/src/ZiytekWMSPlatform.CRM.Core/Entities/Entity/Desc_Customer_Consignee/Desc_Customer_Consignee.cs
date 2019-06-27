using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    /// <summary>
    /// 客户-收货人
    /// </summary>
    public class Desc_Customer_Consignee : INezadaAuditedEntity
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Desc_Customer_Consignee() : base()
        {
           
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="operaterUserId">操作人Id</param>
        public Desc_Customer_Consignee(string operaterUserId) : this()
        {
            CreatorUserId = LastModifierUserId = operaterUserId;
        }
        /// <summary>
        /// 客户Id
        /// </summary>
        public string Customerid { get; set; }
        /// <summary>
        /// 收货人Id
        /// </summary>
        public string Consigneeid { get; set; }
    }
}
