using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using MyABPProject.EntityFramework;

namespace MyABPProject.Migrator
{
    [DependsOn(typeof(MyABPProjectDataModule))]
    public class MyABPProjectMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MyABPProjectDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}