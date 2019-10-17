using System;
using System.Collections.Generic;
using Stocks_Exchange.UnitOfWork;

namespace Stocks_Exchange.BLL.Services
{
    public class StockService : IStockService
    {
        IUnitOfWork unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        { 
            this.unitOfWork = unitOfWork;
        }

        public void createStock(string stockName, string companyName, int exchangeId)
        {
            if (String.IsNullOrEmpty(stockName))
            {
                Console.WriteLine("Stock name can't be empty or null");
                return;
            }

            if (String.IsNullOrEmpty(companyName))
            {
                Console.WriteLine("Company name can't be empty or null");
                return;
            }
            Stock stock = new Stock();
            stock.Company = companyName;
            stock.Name = stockName;
            stock.ExchangeId = exchangeId;
            unitOfWork.Stocks.Add(stock);
            unitOfWork.SaveChanges();
            Console.WriteLine("\nStock " + stockName + " successfully created");
        }

        public void deleteStock(int stockId)
        {
            Stock stock = getStock(stockId);
            if(stock == null)
            {
                Console.WriteLine("\ncant' remobe not existing stock");
                return;
            }
            unitOfWork.Stocks.Remove(stock);
            unitOfWork.SaveChanges();
            Console.WriteLine("\nStock " + stock.Name + " succsessfully deleted");
        }

        public IEnumerable<Stock> getAllStocks()
        {
            return unitOfWork.Stocks.getAll();
        }

        public Stock getStock(int stockId)
        {
            var stock = unitOfWork.Stocks.findById(stockId);
            if (stock is null)
            {
                Console.WriteLine("\nThe list of stocks is empty"); 
            }
            return stock;
        }

        public void updateStock(Stock stockToUpdate, String stockName, String companyName, int exchangeId)
        {
            stockToUpdate.Name = stockName;
            stockToUpdate.Company = companyName;
            stockToUpdate.ExchangeId = exchangeId;
            unitOfWork.Stocks.Update(stockToUpdate);
            unitOfWork.SaveChanges();
            Console.WriteLine("\nStock updated");
        }
        public string stockDetailes(Stock stock)
        {
            Exchange exchange = unitOfWork.Exchanges.findById(stock.ExchangeId);
            string exchangeName = exchange.FullName;
            return "ID:" + stock.Id + "; Name: " + stock.Name + "; Company: " + stock.Company + "; Exchange: " + exchangeName;
        }
    }
}
