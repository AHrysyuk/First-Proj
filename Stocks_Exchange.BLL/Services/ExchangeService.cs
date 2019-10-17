using Stocks_Exchange.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Stocks_Exchange.BLL.Services
{
    public class ExchangeService : IExchangeService
    {
        IUnitOfWork unitOfWork;

        public ExchangeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void createExchange(String shortName, String fullName, string country, string city, short? yearOfFound)
        {
            if (String.IsNullOrEmpty(shortName))
            {
                Console.WriteLine("Exchange shortname can't be empty or null");
                return;
            }
            Exchange exchange = new Exchange();
            exchange.ShortName = shortName;
            exchange.FullName = fullName;
            exchange.Country = country;
            exchange.YearOfFound = yearOfFound;
            exchange.City = city;
            unitOfWork.Exchanges.Add(exchange);
            unitOfWork.SaveChanges();
            Console.WriteLine("\nExchange " + fullName + " successfully created");
        }

        public void deleteExchange(int exchangeId)
        {
            Exchange exchange = getExchange(exchangeId);
            if (exchange == null)
            {
                Console.WriteLine("\ncan't remove not existing exchange");
                return;
            }
            unitOfWork.Exchanges.Remove(exchange);
            unitOfWork.SaveChanges();
            Console.WriteLine("\nExchange " + exchange.FullName + " succsessfully deleted");
        }

        public IEnumerable<Exchange> getAllExchanges()
        {
            return unitOfWork.Exchanges.getAll();
        }

        public Exchange getExchange(int exchangeId)
        {
           return unitOfWork.Exchanges.findById(exchangeId);
        }

        public void updateExchange(Exchange exchangeToUpdate, string exchangeShortName, string exchangeFullName, string exchangeCountry, string exchangeCity, short? exchangeYear)
        {
            exchangeToUpdate.ShortName = exchangeShortName;
            exchangeToUpdate.FullName = exchangeFullName;
            exchangeToUpdate.Country = exchangeCountry;
            exchangeToUpdate.City = exchangeCity;
            exchangeToUpdate.YearOfFound = exchangeYear;
            unitOfWork.Exchanges.Update(exchangeToUpdate);
            unitOfWork.SaveChanges();
            Console.WriteLine("Exchange updated");
        }
        public string exchangeDetailes(Exchange exchange)
        {
            return "ID: " + exchange.Id + " ShortName: " + exchange.ShortName + " FullName: " + exchange.FullName +
               " Country: " + exchange.Country + " City: " + exchange.City + " Year of foundation: " + exchange.YearOfFound;
        }
    }
}


