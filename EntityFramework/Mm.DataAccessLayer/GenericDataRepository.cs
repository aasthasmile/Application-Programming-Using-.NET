using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mm.DataAccessLayer
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        protected SchoolDBEntities Entities;
        private DbSet<T> table = null;

        public GenericDataRepository(SchoolDBEntities entities)
        {
            Entities = entities;
            table = Entities.Set<T>();
        }
  
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public virtual T GetSingle(Func<T, bool> where,
        params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var entity = new SchoolDBEntities())
            {
                IQueryable<T> dbQuery = entity.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                .AsNoTracking() //Don't track any changes for the selected item
                                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public void Insert(T item)
        {
            table.Add(item);
            Entities.SaveChanges();
        }

        public void Update(T item)
        {
            table.Attach(item);
            Entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            Entities.SaveChanges();
        }

        public void Delete(T item)
        {
            table.Remove(item);
            Entities.SaveChanges();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
