using CXD.EntityFramework;
using EntityFramework.DynamicFilters;

namespace CXD.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly CXDDbContext _context;

        public InitialHostDbBuilder(CXDDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
