using fabiostefani.io.PaymentContext.Domain.Enums;
using fabiostefani.io.PaymentContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fabiostefani.io.PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);            
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("12345678901234", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);            
            Assert.IsTrue(doc.Invalid);
        }

        //PARA PASSAR VÁRIOS CASOS EM UM MESMO TESTE
        [TestMethod]
        [DataTestMethod]
        [DataRow("00000000000")]
        [DataRow("11111111111")]
        [DataRow("22222222222")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);            
            Assert.IsTrue(doc.Valid);
        }
    }
}