using Flunt.Validations;

namespace CoinConversion.Domain.ValueObjects
{
    public class Amount : ValueObject
    {
        public Amount(decimal value)
        {
            Value = value;

            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(value, 0, "Amount.Value", "O valor para conversão deve ser maior que zero!")
            );
        }

        public decimal Value { get; private set; }
    }
}