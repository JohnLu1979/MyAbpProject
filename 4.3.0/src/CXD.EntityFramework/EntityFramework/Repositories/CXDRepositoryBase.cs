using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace CXD.EntityFramework.Repositories
{
    public abstract class CXDRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<CXDDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CXDRepositoryBase(IDbContextProvider<CXDDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class CXDRepositoryBase<TEntity> : CXDRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected CXDRepositoryBase(IDbContextProvider<CXDDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
