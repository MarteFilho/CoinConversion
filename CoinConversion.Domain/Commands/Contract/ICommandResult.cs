namespace CoinConversion.Domain.Commands
{
    public interface ICommandResult
    {
        public double Status { get; set; }
        public bool Success { get; set; }
        public dynamic Message { get; set; }
        public object Data { get; set; }
    }
}