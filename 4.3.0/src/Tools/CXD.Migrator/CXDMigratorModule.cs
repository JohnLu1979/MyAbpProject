using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using CXD.EntityFramework;

namespace CXD.Migrator
{
    [DependsOn(typeof(CXDDataModule))]
    public class CXDMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<CXDDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}