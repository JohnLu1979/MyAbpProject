using System.Linq;
using MyABPProject.EntityFramework;
using MyABPProject.MultiTenancy;

namespace MyABPProject.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly MyABPProjectDbContext _context;

        public DefaultTenantCreator(MyABPProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
