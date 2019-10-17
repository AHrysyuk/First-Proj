using System;
using System.Collections.Generic;


namespace Stocks_Exchange.BLL.Services
{
    public interface IStockService
    {
        void createStock(String  stockName, String companyName, int exchangeId);
        void updateStock(Stock stockToUpdate, String stockName, String companyName, int exchangeId);

        void deleteStock(int stockId);

        Stock getStock(int stockId);

        IEnumerable<Stock> getAllStocks();

        string stockDetailes(Stock stock);
    }
}
