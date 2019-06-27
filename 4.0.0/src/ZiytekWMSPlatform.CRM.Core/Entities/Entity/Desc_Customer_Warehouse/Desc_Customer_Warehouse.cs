using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    /// <summary>
    /// 客户-仓库
    /// </summary>
    public class Desc_Customer_Warehouse : INezadaAuditedEntity
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Desc_Customer_Warehouse() : base()
        {
           
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="operaterUserId">操作人Id</param>
        public Desc_Customer_Warehouse(string operaterUserId) : this()
        {
            CreatorUserId = LastModifierUserId = operaterUserId;
        }
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
}
