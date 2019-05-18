using System;
using System.Collections.Generic;
using System.Linq;

namespace fabiostefani.io.PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subcriptions;
        public Student(string firstName, string lastName, string document, string email)
        {
            _subcriptions = new List<Subscription>();
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email; 
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subcriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            //Se ja tiver uma assinatura ativa, cancela e não adiciona uma nova
            //Cancela todas as outras assinaturas e coloca esta como principal
            foreach (var sub in Subscriptions)
            {
                sub.Inactivate();
            }
            _subcriptions.Add(subscription);
        }
    }

}