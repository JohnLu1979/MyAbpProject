using System.Linq;
using CXD.EntityFramework;
using CXD.MultiTenancy;

namespace CXD.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly CXDDbContext _context;

        public DefaultTenantCreator(CXDDbContext context)
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
