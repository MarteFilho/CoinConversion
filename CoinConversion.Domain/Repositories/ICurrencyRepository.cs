using System.Threading.Tasks;
using CoinConversion.Domain.Commands;
using CoinConversion.Domain.Entities;
using CoinConversion.Domain.ValueObjects;

namespace CoinConversion.Domain.Repositories
{
    public interface ICurrencyRepository
    {
        Task<CommandResult> Convert(Currency currency);
        Task<bool> ExistisCurrencies(Coin currencyorigin, Coin currencydestination);
        Task<RatesResponse> GetCurrencies();
    }
}