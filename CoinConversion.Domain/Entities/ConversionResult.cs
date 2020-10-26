namespace CoinConversion.Domain.Entities
{
    public class ConversionResult : Entity
    {
        public ConversionResult(decimal convertedValue, decimal quote)
        {
            ConvertedValue = convertedValue;
            Quote = quote;
        }

        public decimal ConvertedValue { get; }
        public decimal Quote { get; }
    }
}