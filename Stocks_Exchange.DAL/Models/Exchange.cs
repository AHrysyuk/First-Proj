using System;
using System.Collections.Generic;

namespace Stocks_Exchange
{
    public partial class Exchange
    {
        public Exchange()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public short? YearOfFound { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }

    }
}
