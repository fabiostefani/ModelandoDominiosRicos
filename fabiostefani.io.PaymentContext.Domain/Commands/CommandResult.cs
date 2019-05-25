using fabiostefani.io.PaymentContext.Shared.Commands;

namespace fabiostefani.io.PaymentContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
            
        }
        public CommandResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;

        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}