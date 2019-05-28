using fabiostefani.io.PaymentContext.Domain.Entities;
using fabiostefani.io.PaymentContext.Domain.Repositories;

namespace fabiostefani.io.PaymentContext.Tests.Mocks
{
    public class FakeStudentRespository : IStudentRepository
    {
        public void CreateSubcription(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if (document == "12345678901")
                return true;
            
            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "fabiostefani@stefani.io")
                return true;
            
            return false;
        }
    }
}