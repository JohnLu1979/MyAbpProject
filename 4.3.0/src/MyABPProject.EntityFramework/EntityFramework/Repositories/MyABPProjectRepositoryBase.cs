using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MyABPProject.EntityFramework.Repositories
{
    public abstract class MyABPProjectRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MyABPProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MyABPProjectRepositoryBase(IDbContextProvider<MyABPProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MyABPProjectRepositoryBase<TEntity> : MyABPProjectRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MyABPProjectRepositoryBase(IDbContextProvider<MyABPProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
