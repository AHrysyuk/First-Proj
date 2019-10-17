using Stocks_Exchanges.Repositories;
using System;

namespace Stocks_Exchanges.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private StockExchangeDbContext context = new StockExchangeDbContext();

        public UnitOfWork(IStockRepository stocks, IExchangeRepository exchanges)
        {
            Stocks = stocks;
            Exchanges = exchanges;
        }

        public StockExchangeDbContext StockExchangeDbContext { get; }
        public IStockRepository Stocks { get; }

        public IExchangeRepository Exchanges { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
