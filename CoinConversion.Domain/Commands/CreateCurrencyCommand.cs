using CoinConversion.Domain.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

namespace CoinConversion.Domain.Commands
{
    public class CreateCurrencyCommand : Notifiable, ICommand
    {
        public CreateCurrencyCommand() { }

        public CreateCurrencyCommand(decimal amount, string currencyOrigin, string currencyDestination)
        {
            Amount = amount;
            CurrencyOrigin = currencyOrigin;
            CurrencyDestination = currencyDestination;
        }

        public decimal Amount { get; set; }
        public string CurrencyOrigin { get; set; }
        public string CurrencyDestination { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Amount, "Amount", "O valor não pode ser nulo!")
                .IsNotNull(CurrencyOrigin, "CurrencyOrigin", "A moeda de conversão padrão não pode ser nula!")
                .IsNotNull(CurrencyDestination, "CurrencyDestination", "A moeda de conversão de destino não pode ser nula!")
            );
        }
    }
}