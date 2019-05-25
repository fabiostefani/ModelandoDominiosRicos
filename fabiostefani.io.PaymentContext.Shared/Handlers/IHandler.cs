using fabiostefani.io.PaymentContext.Shared.Commands;

namespace fabiostefani.io.PaymentContext.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
         ICommandResult Handle(T command);
    }
}