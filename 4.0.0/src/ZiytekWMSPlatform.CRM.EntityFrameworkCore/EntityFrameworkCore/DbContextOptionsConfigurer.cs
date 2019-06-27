using Microsoft.EntityFrameworkCore;

namespace ZiytekWMSPlatform.CRM.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<CRMDbContext> dbContextOptions,
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for CRMDbContext */
            dbContextOptions.UseMySql(connectionString);
        }
    }
}
