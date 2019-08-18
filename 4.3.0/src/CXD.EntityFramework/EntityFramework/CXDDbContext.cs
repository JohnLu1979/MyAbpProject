using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using CXD.Authorization.Roles;
using CXD.Authorization.Users;
using CXD.Entities;
using CXD.MultiTenancy;
using MySql.Data.Entity;

namespace CXD.EntityFramework
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CXDDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<CNotice> Notices { get; set; }
        public virtual IDbSet<CAccount> Accounts { get; set; }

        public virtual IDbSet<CWeather> CWeatherObjects { get; set; }
        public virtual IDbSet<CTide> CTideObjects { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public CXDDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in CXDDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of CXDDbContext since ABP automatically handles it.
         */
        public CXDDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public CXDDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public CXDDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
