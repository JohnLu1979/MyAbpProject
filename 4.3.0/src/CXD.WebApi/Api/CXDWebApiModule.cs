using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Swashbuckle.Application;

namespace CXD.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(CXDApplicationModule))]
    public class CXDWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(CXDApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //cors.SupportsCredentials = true;
            //GlobalConfiguration.Configuration.EnableCors(cors);

            var cors = new EnableCorsAttribute("*", "*", "*");
            GlobalConfiguration.Configuration.EnableCors(cors);

            ConfigureSwaggerUi();
        }
        public override void PreInitialize()
        {
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
            base.PreInitialize();
        }
        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
            .EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "SwaggerIntegrationDemo.WebApi");
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            //将application层中的注释添加到SwaggerUI中
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                var commentsFileName = "bin\\CXD.Web.xml";
                var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            //将注释的XML文档添加到SwaggerUI中
            c.IncludeXmlComments(commentsFile);
            })
            .EnableSwaggerUi();
        }
    }
}
