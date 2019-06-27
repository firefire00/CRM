using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    /// <summary>
    /// 客户-物资
    /// </summary>
    public class Desc_Customer_Material : INezadaAuditedEntity
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Desc_Customer_Material() : base()
        {
           
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="operaterUserId">操作人Id</param>
        public Desc_Customer_Material(string operaterUserId) : this()
        {
            CreatorUserId = LastModifierUserId = operaterUserId;
        }
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
}
