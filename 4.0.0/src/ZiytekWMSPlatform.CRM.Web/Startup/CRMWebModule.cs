using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ZiytekWMSPlatform.CRM.Configuration;
using ZiytekWMSPlatform.CRM.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ZiytekWMSPlatform.CRM.Web.Startup
{
    /// <summary>
    /// 
    /// </summary>
    [DependsOn(
        typeof(CRMApplicationModule),
        typeof(CRMEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreModule))]
    public class CRMWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public CRMWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(CRMConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<CRMNavigationProvider>();

            //是否封装返回的数据为json格式
            Configuration.Modules.AbpAspNetCore().DefaultWrapResultAttribute.WrapOnSuccess = false;
            //是否格式化返回的数据时间格式
            Configuration.Modules.AbpAspNetCore().UseMvcDateTimeFormatForAppServices = true;

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(CRMApplicationModule).GetAssembly()
                );
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CRMWebModule).GetAssembly());
        }
    }
}