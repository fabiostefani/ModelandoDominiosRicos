using System.Collections.Generic;
using System.Linq;
using fabiostefani.io.PaymentContext.Domain.Entities;
using fabiostefani.io.PaymentContext.Domain.Queries;
using fabiostefani.io.PaymentContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fabiostefani.io.PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(new Name("1", "2"), new Document("12345678901", Domain.Enums.EDocumentType.CPF), new Email("fabio@fabiostefani.io")));
                _students.Add(new Student(new Name("3", "4"), new Document("11111111111", Domain.Enums.EDocumentType.CPF), new Email("fabio@fabiostefani.io")));
            } 
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("99999999999");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678901");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}