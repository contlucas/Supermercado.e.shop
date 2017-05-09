using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Supermercado.E.Shop.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> dataTable;
        protected DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dataTable = dbContext.Set<T>();
        }

        public void Insert(T entity)
        {
            this.dataTable.Add(entity);
        }

        public void Delete(T entity)
        {
            this.dataTable.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return this.dataTable.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return this.dataTable;
        }

        public T GetById(int id)
        {
            return this.dataTable.Find(id);
        }
    }
}
