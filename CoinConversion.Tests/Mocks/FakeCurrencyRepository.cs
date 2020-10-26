using System.Threading.Tasks;
using CoinConversion.Domain.Commands;
using CoinConversion.Domain.Entities;
using CoinConversion.Domain.Repositories;
using CoinConversion.Domain.ValueObjects;

namespace CoinConversion.Tests.Mocks
{
    public class FakeCurrencyRepository : ICurrencyRepository
    {
        public Task<CommandResult> Convert(Currency currency)
        {
            return Task.FromResult(new CommandResult(200, true, "", null));
        }

        public Task<bool> ExistisCurrencies(Coin currencyorigin, Coin currencydestination)
        {
            if (currencyorigin.Name == "USD" && currencydestination.Name == "BRL")
                return Task.FromResult(true);
            return Task.FromResult(false);
        }

        public Task<RatesResponse> GetCurrencies()
        {
            return Task.FromResult(new RatesResponse());
        }
    }
}