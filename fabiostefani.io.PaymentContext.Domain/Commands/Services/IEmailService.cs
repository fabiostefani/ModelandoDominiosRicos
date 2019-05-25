namespace fabiostefani.io.PaymentContext.Domain.Commands.Services
{
    public interface IEmailService
    {
         void Send(string to, string email, string subject, string body);
    }
}