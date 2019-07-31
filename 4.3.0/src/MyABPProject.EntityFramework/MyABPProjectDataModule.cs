using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using MyABPProject.EntityFramework;

namespace MyABPProject
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(MyABPProjectCoreModule))]
    public class MyABPProjectDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyABPProjectDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
