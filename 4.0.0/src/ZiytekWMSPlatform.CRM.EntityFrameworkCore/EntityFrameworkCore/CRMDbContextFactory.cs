using ZiytekWMSPlatform.CRM.Configuration;
using ZiytekWMSPlatform.CRM.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ZiytekWMSPlatform.CRM.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class CRMDbContextFactory : IDesignTimeDbContextFactory<CRMDbContext>
    {
        public CRMDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CRMDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(CRMConsts.ConnectionStringName)
            );

            return new CRMDbContext(builder.Options);
        }
    }
}