using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace ZiytekWMSPlatform.CRM.EntityFrameworkCore
{
    [DependsOn(
        typeof(CRMCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class CRMEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CRMEntityFrameworkCoreModule).GetAssembly());
        }
    }
}