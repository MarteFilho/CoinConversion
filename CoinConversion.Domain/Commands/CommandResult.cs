namespace CoinConversion.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(double status, bool success, dynamic message, object data)
        {
            Status = status;
            Success = success;
            Message = message;
            Data = data;
        }

        public double Status { get; set; }
        public bool Success { get; set; }
        public dynamic Message { get; set; }
        public object Data { get; set; }
    }
}