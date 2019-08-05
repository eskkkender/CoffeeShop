using DAL.Abstraction;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EntityFramework
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected readonly DbContext Context;
        private readonly IDbSet<T> DbSet;

        public RepositoryBase(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public void Create(T item)
        {
           DbSet.Add(item);
        }

        public void Delete(T item)
        {
            try
            {
                DbSet.Remove(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           
        }

        public IQueryable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
