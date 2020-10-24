using CoinConversion.Domain.Contract;

namespace CoinConversion.Domain.Models
{
    public sealed class ConversionResult : Entity
    {
        public decimal ConvertedValue { get; }
        public string CurrencyOrigin { get; }
        public string CurrencyDestination { get; }
    }
}