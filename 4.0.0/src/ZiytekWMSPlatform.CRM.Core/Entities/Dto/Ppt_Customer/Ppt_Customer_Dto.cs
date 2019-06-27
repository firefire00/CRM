using System;
using Nezada.Common.Abp.Entity;

namespace ZiytekWMSPlatform.CRM.Entities
{
    #region 实体输入类
    /// <summary>
    /// 客户实体输入类
    /// </summary>
    public class Ppt_Customer_InputDto : INezadaEntityInputDto<string>
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
        /// 是否属于个人
        /// </summary>
        public bool? Ispersonal { get; set; }
        /// <summary>
        /// 客户类型
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
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string District { get; set; }
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

    #region 实体输出类
    /// <summary>
    /// 客户实体输出类
    /// </summary>
    public class Ppt_Customer_OutputDto : INezadaEntityOutputDto<string>
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
        /// 是否属于个人
        /// </summary>
        public bool? Ispersonal { get; set; }
        /// <summary>
        /// 客户类型
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
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string District { get; set; }
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
}
