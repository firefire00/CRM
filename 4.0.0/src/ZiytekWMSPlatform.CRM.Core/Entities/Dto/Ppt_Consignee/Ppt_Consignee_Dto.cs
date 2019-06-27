using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    #region 实体输入类
    /// <summary>
    /// 收货人实体输入类
    /// </summary>
    public class Ppt_Consignee_InputDto : INezadaEntityInputDto<string>
    {
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
    #endregion

    #region 实体输出类
    /// <summary>
    /// 收货人实体输出类
    /// </summary>
    public class Ppt_Consignee_OutputDto : INezadaEntityOutputDto<string>
    {
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
    #endregion
}
