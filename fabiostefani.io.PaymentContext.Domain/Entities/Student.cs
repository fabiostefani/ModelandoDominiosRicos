using System;
using System.Collections.Generic;
using System.Linq;
using fabiostefani.io.PaymentContext.Domain.ValueObjects;
using fabiostefani.io.PaymentContext.Shared.Entities;

namespace fabiostefani.io.PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subcriptions;
        public Student(Name name, Document document, Email email)
        {
            _subcriptions = new List<Subscription>();
            Name = name;            
            Document = document;
            Email = email; 

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }    
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
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