using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mm.DataAccessLayer
{
    public interface IGenericDataRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
    }
}
