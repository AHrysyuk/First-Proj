﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks_Exchange.Repositories
{
    public class ExchangeRepository : Repository<Exchange>, IExchangeRepository
    {
        private readonly StockExchangeDbContext Context;
        public ExchangeRepository(StockExchangeDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
