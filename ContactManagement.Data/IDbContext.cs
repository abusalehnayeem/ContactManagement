using System.Data.Entity;
using ContactManagement.Core.Entity;

namespace ContactManagement.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
