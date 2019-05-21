using fabiostefani.io.PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace fabiostefani.io.PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            this.Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Adrress", "E-mail inválido")
            );

        }
        public string Address { get; private set; }
    }
}