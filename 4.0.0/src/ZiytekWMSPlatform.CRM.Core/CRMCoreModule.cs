using Abp.Modules;
using Abp.Reflection.Extensions;
using ZiytekWMSPlatform.CRM.Localization;

namespace ZiytekWMSPlatform.CRM
{
    public class CRMCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            CRMLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CRMCoreModule).GetAssembly());
        }
    }
}