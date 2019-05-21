using System;
using fabiostefani.io.PaymentContext.Domain.Entities;
using fabiostefani.io.PaymentContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fabiostefani.io.PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var student = new Student("Fabio", "de Stefani", "123456", "fabioste@fabiostefani.io");            
        }

        [TestMethod]
        public void AdicionarAssinatura()
        {
            var name = new Name("Teste", "Teste");
             //name.Notifications
             foreach (var item in name.Notifications)
             {
                 //item.
             }
            // var subscription = new Subscription(null);
            // var student = new Student("Fabio", "de Stefani", "123456", "fabioste@fabiostefani.io");            
            // student.AddSubscription(subscription);
        }
    }
}