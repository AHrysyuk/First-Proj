using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks_Exchanges.Repositories
{
    public interface IRepository<T> where T:class
    {
        void Update(T entity);
        void Add(T entity);
        void Add(IEnumerable<T> entities);
        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
    }
 
}
