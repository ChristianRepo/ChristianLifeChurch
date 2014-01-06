using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristianLifeChurch.Core.DataBaseContext;

namespace ChristianLifeChurch.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T item);
        void Update(T item);
        void Delete(long id);
        void Delete(T item);
        void SaveOrUpdate(T item);
        void SaveChanges();
    }

    public abstract class  GeneralRepository<T>:IRepository<T> where T:class
    {
         protected readonly DbContext dbContext;

        protected DbSet<T> dbSet;

        protected GeneralRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }
        protected GeneralRepository()
        {
            this.dbContext = new ChurchContext();
            dbSet = this.dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }
       
        public T Get(long id)
        {
            return dbSet.Find(id);
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Update(T item)
        {
            dbSet.Attach(item);
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            var item =dbSet.Find(id);
            Delete(item);
        }

        public void Delete(T item)
        {
            if (dbContext.Entry(item).State == EntityState.Detached)
            {
                dbSet.Attach(item);
            }
            dbSet.Remove(item);
        }

        public void SaveOrUpdate(T item)
        {
            dbSet.AddOrUpdate(item);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
