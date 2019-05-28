using fabiostefani.io.PaymentContext.Domain.Commands.Services;

namespace fabiostefani.io.PaymentContext.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            
        }
    }
}