using System.Linq;
using ContactManagement.Core.Entity;

namespace ContactManagement.Data
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get; }
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}