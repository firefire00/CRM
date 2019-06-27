using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nezada.Common.Extensions;
using Nezada.Common.Rabbit;
using Nezada.Common.ServiceUri;
using ZiytekWMSPlatform.CRM.EntityFrameworkCore;

namespace ZiytekWMSPlatform.CRM.Web.Startup
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 配置
        /// </summary>
        public IConfigurationRoot ConfigurationRoot1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            ConfigurationRoot1 = builder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Configure DbContext
            services.AddAbpDbContext<CRMDbContext>(options =>
            {
                DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            });

            //CAP
            string connectionString = ConfigurationRoot1.GetConnectionString("Default");
            var rabbit = ConfigurationRoot1.GetOptions<RabbitOptions>("Rabbit");
            services.AddCap(options =>
            {
                // 如果你的 SqlServer 使用的 EF 进行数据操作，你需要添加如下配置：
                // 注意: 你不需要再次配置 x.UseSqlServer(""")
                options.UseEntityFramework<CRMDbContext>();

                //使用MySQL
                options.UseMySql(cfg =>
                {
                    cfg.ConnectionString = connectionString;
                });

                // 如果你使用的 RabbitMQ 作为MQ，你需要添加如下配置：
                options.UseRabbitMQ(cfg =>
                {
                    cfg.HostName = rabbit?.HostName;
                    cfg.VirtualHost = rabbit?.VirtualHost;
                    cfg.Port = rabbit == null ? 5672 : rabbit.Port;
                    cfg.UserName = rabbit?.UserName;
                    cfg.Password = rabbit?.Password;
                    cfg.ExchangeName = rabbit?.ExchangeName;
                });

                options.FailedRetryCount = 5;
            });

            //跨域
            services.AddCors(option => option.AddPolicy("Cors", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin()));

            services.AddOptions();
            services.Configure<ServiceUri>(ConfigurationRoot1.GetSection("ServiceUri"));

            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
            .AddJsonOptions(options =>
            {
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            services.AddApiDoc(t =>
            {
                t.ApiDocPath = "apidoc";//api访问路径
                t.Title = "CRM接口文档";
            });

            //Configure Abp and Dependency Injection
            return services.AddAbp<CRMWebModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); //Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "CRM",
                template: "CRM/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
