using fabiostefani.io.PaymentContext.Shared.ValueObjects;

namespace fabiostefani.io.PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            this.Address = address;

        }
        public string Address { get; private set; }
    }
}