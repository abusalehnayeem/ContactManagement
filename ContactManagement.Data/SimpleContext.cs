using System.Data.Entity;
using ContactManagement.Core.Entity;

namespace ContactManagement.Data
{
    //public class SimpleContext:DbContext,IDbContext
    public class SimpleContext : DbContext
    {
        public SimpleContext() : base("DefaultDbContext")
        {
            Database.SetInitializer(new MyDbInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }

        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}
    }
}
