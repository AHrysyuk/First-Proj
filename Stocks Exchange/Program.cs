using Microsoft.Extensions.DependencyInjection;
using Stocks_Exchange.BLL.Services;
using Stocks_Exchange.ConsoleActions;
using Stocks_Exchange.UnitOfWork;
using System;
using System.Linq;

namespace Stocks_Exchange
{
    public class Program
    {

        public static void Main(string[] args)
        {

            using var serviceProvider = ConfigureServices();
            IStockService stockService = serviceProvider.GetService<IStockService>();
            IExchangeService exchangeService = serviceProvider.GetService<IExchangeService>();
            ConsoleAction consoleAction = new ConsoleAction(stockService, exchangeService);
            consoleAction.Start();
        }
        public static ServiceProvider ConfigureServices()
        {
                ServiceCollection serviceCollection = new ServiceCollection();
                serviceCollection.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
                serviceCollection.AddTransient<IStockService, StockService>();
                serviceCollection.AddTransient<IExchangeService, ExchangeService>();
                return serviceCollection.BuildServiceProvider();
        }
      
        }
    }

