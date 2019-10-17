using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Stocks_Exchange.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        private readonly StockExchangeDbContext Context;
        public StockRepository(StockExchangeDbContext context) : base(context)
        {
            Context = context;
        }

        
    }
}
