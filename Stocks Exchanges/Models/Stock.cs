using System;
using System.Collections.Generic;

namespace Stocks_Exchanges
{
    public partial class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int ExchangeId { get; set; }

        public virtual Exchange Exchange { get; set; }
    }
}
