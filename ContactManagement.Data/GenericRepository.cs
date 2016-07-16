using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using ContactManagement.Core.Entity;

namespace ContactManagement.Data
{
    public sealed class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public GenericRepository()
        {
            _simpleContext = new SimpleContext();
        }

        private IDbSet<T> Entity => _entity ?? (_entity = _simpleContext.Set<T>());

        public IQueryable<T> Table => Entity;

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Entity.Remove(entity);
                _simpleContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var err in dbEx.EntityValidationErrors.SelectMany(errors => errors.ValidationErrors))
                {
                    _errorMessage += string.Format("Property {0} Error {1}", err.PropertyName, err.ErrorMessage) +
                                     Environment.NewLine;
                    throw new Exception(_errorMessage, dbEx);
                }
            }
        }

        public T GetById(object id)
        {
            return Entity.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                Entity.Add(entity);
                _simpleContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var err in dbEx.EntityValidationErrors.SelectMany(errors => errors.ValidationErrors))
                {
                    _errorMessage += string.Format("Property {0} Error {1}", err.PropertyName, err.ErrorMessage) +
                                     Environment.NewLine;
                    throw new Exception(_errorMessage, dbEx);
                }
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                _simpleContext.Entry(entity).State = EntityState.Modified;
                _simpleContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var err in dbEx.EntityValidationErrors.SelectMany(errors => errors.ValidationErrors))
                {
                    _errorMessage += string.Format("Property {0} Error {1}", err.PropertyName, err.ErrorMessage) +
                                     Environment.NewLine;
                    throw new Exception(_errorMessage, dbEx);
                }
            }
        }

        #region Variable

        private readonly SimpleContext _simpleContext;
        private IDbSet<T> _entity;
        private string _errorMessage = string.Empty;

        #endregion
    }
}