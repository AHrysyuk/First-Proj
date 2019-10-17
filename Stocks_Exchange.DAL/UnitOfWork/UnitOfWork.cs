using Stocks_Exchange.Repositories;
using System;

namespace Stocks_Exchange.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        
        public UnitOfWork()
        {
            StockExchangeDbContext = new StockExchangeDbContext();
            Stocks = new StockRepository(StockExchangeDbContext);
            Exchanges = new ExchangeRepository(StockExchangeDbContext);
        }

        public StockExchangeDbContext StockExchangeDbContext { get; }
        public IStockRepository Stocks { get; }

        public IExchangeRepository Exchanges { get; }

        public void Dispose()
        {
            StockExchangeDbContext.Dispose();
        }

        public int SaveChanges()
        {
            return StockExchangeDbContext.SaveChanges();
        }
    }
}
