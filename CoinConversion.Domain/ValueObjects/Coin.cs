using Flunt.Validations;

namespace CoinConversion.Domain.ValueObjects
{
    public class Coin : ValueObject
    {
        public Coin(string name)
        {
            Name = name;
            AddNotifications(
                new Contract()
                    .Requires()
                        .HasLen(name, 3, "Coin.Name", "Favor inserir uma moeda válida."));
        }

        public string Name { get; private set; }
    }
}