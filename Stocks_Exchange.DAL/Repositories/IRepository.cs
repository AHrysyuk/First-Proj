using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks_Exchange.Repositories
{
    public interface IRepository<T> where T:class
    {
        T findById(int id);
        IEnumerable<T> getAll();
        void Update(T entity);
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
    }
 
}
