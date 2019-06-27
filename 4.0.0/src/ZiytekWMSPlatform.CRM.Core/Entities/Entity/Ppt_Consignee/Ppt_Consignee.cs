using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    /// <summary>
    /// 收货人
    /// </summary>
    public class Ppt_Consignee : INezadaAuditedEntity
    {
        /// <summary>
        /// 构造
        /// </summary>
        public Ppt_Consignee() : base()
        {
           
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="operaterUserId">操作人Id</param>
        public Ppt_Consignee(string operaterUserId) : this()
        {
            CreatorUserId = LastModifierUserId = operaterUserId;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Consigneename { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobilephone { get; set; }
        /// <summary>
        /// 收货单位
        /// </summary>
        public string Receivingunit { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public string Warehouseid { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string ProvinceText { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string CityText { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string AreaText { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Detailaddress { get; set; }
    }
}
