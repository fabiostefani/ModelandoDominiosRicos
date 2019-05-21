using fabiostefani.io.PaymentContext.Shared.ValueObjects;

namespace fabiostefani.io.PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
                AddNotification("FirstName", "Nome inválido");

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}