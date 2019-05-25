using System;
using fabiostefani.io.PaymentContext.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fabiostefani.io.PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubcriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsIsvalid()
        {
            var command = new CreateBoletoSubcriptionCommand();
            command.FirstName = "";
            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }

    }
}