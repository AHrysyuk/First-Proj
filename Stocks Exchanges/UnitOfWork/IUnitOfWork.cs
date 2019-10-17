using System;
using System.Collections.Generic;
using System.Text;
using Stocks_Exchanges.Repositories;

namespace Stocks_Exchanges.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStockRepository Stocks { get; }
        IExchangeRepository Exchanges { get; }

        int SaveChanges();
    }
}
