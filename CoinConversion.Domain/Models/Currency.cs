using CoinConversion.Domain.Contract;

namespace CoinConversion.Domain.Models
{
    public sealed class Currency : Entity
    {
        public Currency(decimal amount, string currencyOrigin, string currencyDestination)
        {
            Amount = amount;
            CurrencyOrigin = currencyOrigin;
            CurrencyDestination = currencyDestination;
        }

        public decimal Amount { get; }
        public string CurrencyOrigin { get; }
        public string CurrencyDestination { get; }

    }
}