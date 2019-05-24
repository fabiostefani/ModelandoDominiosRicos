using System;
using fabiostefani.io.PaymentContext.Domain.Entities;
using fabiostefani.io.PaymentContext.Domain.Enums;
using fabiostefani.io.PaymentContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fabiostefani.io.PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {        
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("01234567890", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua", "11", "Gotham", "Gotham", "SC", "Brazil", "88888-888");

            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);

            
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscriptions()
        {
            var payment = new PayPalPayment("123456789",  DateTime.Now, DateTime.Now.AddDays(5), 10,10, "WAYNE CORP", _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionsHasNoPayment()
        {            
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscriptions()
        {
            var payment = new PayPalPayment("123456789",  DateTime.Now, DateTime.Now.AddDays(5), 10,10, "WAYNE CORP", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}