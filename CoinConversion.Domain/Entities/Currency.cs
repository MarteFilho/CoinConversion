using CoinConversion.Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace CoinConversion.Domain.Entities
{
    public class Currency : Entity
    {
        public Currency(Amount amount, Coin currencyOrigin, Coin currencyDestination)
        {
            Amount = amount;
            CurrencyOrigin = currencyOrigin;
            CurrencyDestination = currencyDestination;

            AddNotifications(amount, currencyOrigin, currencyDestination);
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(currencyOrigin.Name, currencyDestination.Name, "Currency", "As moedas para conversão não podem ser iguais!")
            );
        }

        public Amount Amount { get; }
        public Coin CurrencyOrigin { get; }
        public Coin CurrencyDestination { get; }

        public decimal Convert(decimal quote)
        {
            return Amount.Value * quote;
        }

    }
}