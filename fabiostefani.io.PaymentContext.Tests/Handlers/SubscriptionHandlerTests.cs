using System;
using fabiostefani.io.PaymentContext.Domain.Commands;
using fabiostefani.io.PaymentContext.Domain.Enums;
using fabiostefani.io.PaymentContext.Domain.Handlers;
using fabiostefani.io.PaymentContext.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fabiostefani.io.PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRespository(), new FakeEmailService());
            var command = new CreateBoletoSubcriptionCommand();
            command.BarCode = "1234567890123";
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "12345678901";
            command.Email = "fabio@fabio.com";        
            command.BoletoNumber = "1234567890";
            command.PaymentNumber = "123123";
            command.PaidDate = DateTime.Now ;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayne Corp";
            command.PayerDocument = "12345678901";
            command.PayerDocumentType = EDocumentType.CPF ;
            command.PayerEmail = "batman@dc.com";
            command.Street = "asd asd";
            command.Number = "a sdaa sd";
            command.Neighborhood = "a sda dasd";
            command.City = "a sdad as";
            command.State = "a sda d";
            command.Country = "a sdasd asd";
            command.ZipCode = "a sdasd asd ";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}