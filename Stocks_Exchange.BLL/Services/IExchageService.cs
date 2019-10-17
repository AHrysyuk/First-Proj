using System;
using System.Collections.Generic;

namespace Stocks_Exchange.BLL.Services
{
    public interface IExchangeService
    {
        void createExchange(String shortName, String fullName, string country, string city, short? yearOfFound);
        void updateExchange(Exchange exchangeToUpdate, string exchangeShortName, string exchangeFullName, string exchangeCountry, string exchangeCity, short? exchangeYear);

        void deleteExchange(int exchangeId);

        Exchange getExchange(int exchangeId);

        IEnumerable<Exchange> getAllExchanges();

        string exchangeDetailes(Exchange exchange);
    }
}
