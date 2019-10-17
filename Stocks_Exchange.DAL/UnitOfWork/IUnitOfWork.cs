using System;
using System.Collections.Generic;
using System.Text;
using Stocks_Exchange.Repositories;

namespace Stocks_Exchange.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IStockRepository Stocks { get; }
        IExchangeRepository Exchanges { get; }

        int SaveChanges();
    }
}
