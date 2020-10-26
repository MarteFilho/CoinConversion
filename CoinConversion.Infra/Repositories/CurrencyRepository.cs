using System;
using System.Threading.Tasks;
using CoinConversion.Domain.Commands;
using CoinConversion.Domain.Entities;
using CoinConversion.Domain.Repositories;
using CoinConversion.Domain.ValueObjects;
using CoinConversion.Infra.Services;
using Refit;

namespace CoinConversion.Infra.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public decimal quote;
        public async Task<CommandResult> Convert(Currency currency)
        {
            try
            {
                var service = RestService.For<IRatesServices>("https://api.exchangeratesapi.io/");
                var rates = await service.GetRatesWithBaseAsync(currency.CurrencyOrigin.Name);
                rates.Values.TryGetValue(currency.CurrencyDestination.Name, out quote);

                var convertedvalue = currency.Convert(quote);

                var conversionresult = new ConversionResult(convertedvalue, quote);
                return new CommandResult(200, true, "Conversão feita com sucesso!", conversionresult);
            }
            catch
            {
                return new CommandResult(400, false, "Erro ao realizar a conversão", null);
            }
        }

        public async Task<bool> ExistisCurrencies(Coin currencyorigin, Coin currencydestination)
        {
            var service = RestService.For<IRatesServices>("https://api.exchangeratesapi.io/");
            var rates = await service.GetRatesAsync();
            bool existiscurrencyorigin = rates.Values.TryGetValue(currencyorigin.Name, out quote);
            bool existiscurrencydestination = rates.Values.TryGetValue(currencydestination.Name, out quote);

            if (existiscurrencyorigin == true && existiscurrencydestination == true)
                return true;
            return false;
        }

        public async Task<RatesResponse> GetCurrencies()
        {
            var service = RestService.For<IRatesServices>("https://api.exchangeratesapi.io/");
            var rates = await service.GetRatesAsync();
            return rates;
        }
    }
}