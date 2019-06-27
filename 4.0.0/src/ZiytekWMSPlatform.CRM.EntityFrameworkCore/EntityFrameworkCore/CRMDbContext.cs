using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZiytekWMSPlatform.CRM.Entities;

namespace ZiytekWMSPlatform.CRM.EntityFrameworkCore
{
    public class CRMDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        /// <summary>
        /// 客户
        /// </summary>
        public DbSet<Ppt_Customer> PPT_CUSTOMER { get; set; }
        /// <summary>
        /// 客户-仓库
        /// </summary>
        public DbSet<Desc_Customer_Warehouse> DESC_CUSTOMER_WAREHOUSE { get; set; }
        /// <summary>
        /// 客户-收货人
        /// </summary>
        public DbSet<Desc_Customer_Consignee> DESC_CUSTOMER_CONSIGNEE { get; set; }
        /// <summary>
        /// 客户-物资
        /// </summary>
        public DbSet<Desc_Customer_Material> DESC_CUSTOMER_MATERIAL { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public DbSet<Ppt_Consignee> PPT_CONSIGNEE { get; set; }

        public CRMDbContext(DbContextOptions<CRMDbContext> options)
            : base(options)
        {

        }
    }
}
