using Stocks_Exchange.BLL.Services;
using System;
using System.Collections.Generic;

namespace Stocks_Exchange.ConsoleActions
{
    public class ConsoleAction
    {
        IStockService stockService;
        IExchangeService exchangeService;
        public ConsoleAction(IStockService stockService, IExchangeService exchangeService)
        {
            this.stockService = stockService;
            this.exchangeService = exchangeService;
        }
        public void Start()
        {
            Console.WriteLine("\nPlease select number of object: " +
                "\n 1. Stocks " +
                "\n 2. Exchanges" +
                "\n 3. Close program");
            var start = Console.ReadLine();
            if (start == "1")
            {
                stockMenu();
            }
            else if (start == "2")
            {
                exchangeMenu();
            }
            else if (start == "3")
            {
                Exit();
            }
            else
            {
                Console.WriteLine("\nYou must press 1,2 or 3.");
                Start();
            }
        }

        public void Exit()
        {
            Console.WriteLine("\nSee you soon, bye");
            Environment.Exit(0);
        }
        public void stockMenu()
        {
            Console.WriteLine("\nWhat action do you want to do with the stock? Choose a number:" +
                "\n 1. Add stock" +
                "\n 2. Update stock" +
                "\n 3. Delete stock" +
                "\n 4. Find stock by ID" +
                "\n 5. Get All stocks" +
                "\n 6. Return to the start menu" +
                "\n 7. Close program");

            switch (Console.ReadLine())
            {
                case "1":
                    addStock();
                    break;
                case "2":
                    showStocks();
                    updateStock();
                    break;
                case "3":
                    showStocks();
                    deleteStock();
                    break;
                case "4":
                    Console.WriteLine("\nInsert Id of stock");
                    int stockId = ConvertToInt(Console.ReadLine());
                    if (stockId == 0)
                    {
                        Console.WriteLine("\nInvalid Input. Choose correct ID");
                        Console.ReadKey();
                        goto case "4";
                    }
                    var stock = stockService.getStock(stockId);
                    Console.WriteLine(stockService.stockDetailes(stock));
                    Console.ReadKey();
                    stockMenu();
                    break;
                case "5":
                    showStocks();
                    Console.ReadKey();
                    stockMenu();
                    break;
                case "6":
                    Start();
                    break;
                case "7":
                    Exit();
                    ;
                    break;
                default:
                    Console.WriteLine("\nDo not try my patience. Select the correct symbol!");
                    stockMenu();
                    break;
            }
        }
        private int ConvertToInt(String userInput)
        {
            try
            {
                return Convert.ToInt32(userInput);
            }
            catch 
            {
                return 0;
            }
        }

        private void addStock()
        {
            Console.WriteLine("\nEnter stock name");
            String stockName = Console.ReadLine();
            if (String.IsNullOrEmpty(stockName))
            {
                Console.WriteLine("\nStock name can't be empty. Try again");
                addStock();
            }
            Console.WriteLine("\nEnter company name");
            String companyName = Console.ReadLine();
            if (String.IsNullOrEmpty(companyName))
            {
                Console.WriteLine("\nCompany name can't be empty. Try again");
                addStock();
            }
            showExchanges();
            Console.WriteLine("\nEnter exchange id");
            int exchangeId = ConvertToInt(Console.ReadLine());
            Exchange exchange = exchangeService.getExchange(exchangeId);
            if (exchange == null)
            {
                Console.WriteLine("\nFailed to find exchange. Try add stock again");
                addStock();
            }
            stockService.createStock(stockName, companyName, exchangeId);
            Console.ReadKey();
            stockMenu();
        }

        private void updateStock()
        {
            Console.WriteLine("\nEnter stock id to update");
            int stockId = ConvertToInt(Console.ReadLine());
            Stock stockToUpdate = stockService.getStock(stockId);
            if (stockToUpdate is null)
            {
                Console.WriteLine("\nPlease enter valide stock id to update");
                updateStock();
            }
            Console.WriteLine("\nEnter stock name");
            String stockName = Console.ReadLine();
            if (String.IsNullOrEmpty(stockName))
            {
                Console.WriteLine("\nStock name can't be empty. Try again");
                updateStock();
            }
            Console.WriteLine("\nEnter company name");
            String companyName = Console.ReadLine();
            if (String.IsNullOrEmpty(companyName))
            {
                Console.WriteLine("\nCompany name can't be empty. Try again");
                updateStock();
            }
            Console.WriteLine("\nEnter exchange id");
            int exchangeId = ConvertToInt(Console.ReadLine());
            Exchange exchange = exchangeService.getExchange(exchangeId);
            if (exchange == null)
            {
                Console.WriteLine("\nFailed to find exchange");
                updateStock();
            }
            stockService.updateStock(stockToUpdate, stockName, companyName, exchangeId);
            Console.ReadKey();
            stockMenu();
        }
        private void deleteStock()
        {
            Console.WriteLine("\nEnter stock id to delete");
            int stockId = ConvertToInt(Console.ReadLine());
            Stock stock = stockService.getStock(stockId);
            if (stock == null)
            {
                Console.WriteLine("\nFailed to find stock.Try again");
                deleteStock();
                return;
            }
            stockService.deleteStock(stockId);
            Console.ReadKey();
            stockMenu();
        }
        public void exchangeMenu()
        {
            Console.WriteLine("\nWhat action do you want to do with the stock? Choose a number:" +
                "\n 1. Add exchange" +
                "\n 2. Update exchange" +
                "\n 3. Delete exchange" +
                "\n 4. Find exchange by ID" +
                "\n 5. Get All exchange" +
                "\n 6. Return to the start menu" +
                "\n 7. Close program");

            switch (Console.ReadLine())
            {
                case "1":
                    addExchange();
                    break;
                case "2":
                    showExchanges();
                    updateExchange();
                    break;
                case "3":
                    showExchanges();
                    deleteExchange();
                    break;
                case "4":
                    Console.WriteLine("\nInsert Id of exchange");
                    int exchangeId = ConvertToInt(Console.ReadLine());
                    if (exchangeId == 0)
                    {
                        Console.WriteLine("\nInvalid Input. Try again");
                        Console.ReadKey();
                        goto case "4";
                    }
                    Exchange exchange = exchangeService.getExchange(exchangeId);
                    Console.WriteLine(exchangeService.exchangeDetailes(exchange));
                    Console.ReadKey();
                    exchangeMenu();
                    break;
                case "5":
                    showExchanges();
                    Console.ReadKey();
                    exchangeMenu();
                    break;
                case "6":
                    Start();
                    break;
                case "7":
                    Exit();
                    break;
                default:
                    Console.WriteLine("\nSelect the correct symbol");
                    exchangeMenu();
                    break;
            }
        }
        private void addExchange()
        {
            Console.WriteLine("\nEnter exchange short name");
            String exchangeShortName = Console.ReadLine();
            if (String.IsNullOrEmpty(exchangeShortName))
            {
                Console.WriteLine("\nShort Name can't be empty. Try again");
                addExchange();
            }
            Console.WriteLine("\nEnter exchange full name");
            String exchangeFullName = Console.ReadLine();
            if (String.IsNullOrEmpty(exchangeFullName))
            {
                Console.WriteLine("\nFull Name can't be empty. Try again");
                addExchange();
            }
            Console.WriteLine("\nEnter contry of exchange");
            string exchangeCountry = Console.ReadLine();
            Console.WriteLine("\nEnter city base of exchange");
            string exchangeCity = Console.ReadLine();
            Console.WriteLine("\nEnter year of foundation");

            short? exchangeYear;
            try
            {
                exchangeYear = Convert.ToInt16(Console.ReadLine()); 
            }
            catch
            {
                exchangeYear = null;
            }
            exchangeService.createExchange(exchangeShortName, exchangeFullName, exchangeCountry, exchangeCity, exchangeYear);
            Console.ReadKey();
            exchangeMenu();
        }
        private void updateExchange()
        {
            Console.WriteLine("\nEnter exchange id to update");
            int exchangeId = ConvertToInt(Console.ReadLine());
            Exchange exchangeToUpdate = exchangeService.getExchange(exchangeId);
            if (exchangeToUpdate is null)
            {
                Console.WriteLine("\nPlease enter valide exchange id to update");
                updateExchange();
            }
            Console.WriteLine("\nEnter exchange short name");
            String exchangeShortName = Console.ReadLine();
            if (String.IsNullOrEmpty(exchangeShortName))
            {
                Console.WriteLine("\nShort Name can't be empty. Try again");
                updateExchange();
            }
            Console.WriteLine("\nEnter exchange full name");
            String exchangeFullName = Console.ReadLine();
            if(String.IsNullOrEmpty(exchangeFullName))
            {
                Console.WriteLine("\nFull Name can't be empty. Try again");
                updateExchange();
            }
            Console.WriteLine("\nEnter contry of exchange");
            string exchangeCountry = Console.ReadLine();
            Console.WriteLine("\nEnter city base of exchange");
            string exchangeCity = Console.ReadLine();
            Console.WriteLine("\nEnter year of foundation");
            short? exchangeYear;
            try
            {
                exchangeYear = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                exchangeYear = null;
            }
            exchangeService.updateExchange(exchangeToUpdate, exchangeShortName, exchangeFullName, exchangeCountry, exchangeCity, exchangeYear);
            Console.ReadKey();
            exchangeMenu();
        }
        private void deleteExchange()
        {
            showExchanges();
            Console.WriteLine("\nEnter exchange id to delete");
            int exchangeId = ConvertToInt(Console.ReadLine());
            Exchange exchange = exchangeService.getExchange(exchangeId);
            if (exchange  == null)
            {
                Console.WriteLine("\ncant' remobe not existing exchange");
                deleteExchange();
                return;
            }
            exchangeService.deleteExchange(exchangeId);
            Console.ReadKey();
            exchangeMenu();
        }
        private void showStocks()
        {
            IEnumerable<Stock> stocks = stockService.getAllStocks();
            foreach (Stock st in stocks)
            {
                Console.WriteLine("\n" + stockService.stockDetailes(st));
            }
        }
        private void showExchanges()
        {
            IEnumerable<Exchange> exchanges = exchangeService.getAllExchanges();
            foreach (Exchange ex in exchanges)
            {
                Console.WriteLine("\n" + exchangeService.exchangeDetailes(ex));
            }
        }
    }
}

