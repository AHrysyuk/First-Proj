using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Stocks_Exchanges.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> Entities;
        public Repository(DbContext context)
        {
            Entities = context.Set<T>();
        }
        public T GetById(int id)
        {
            return Entities.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }
        public void Update(T entity)
        {
            Entities.Update(entity);
        }
        public void Add(T entity)
        {
            Entities.Add(entity);
        }
        public void Add(IEnumerable<T> entities)
        {
            Entities.AddRange(entities);
        }
        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }
        public void Remove(IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);
        }
    }
}
