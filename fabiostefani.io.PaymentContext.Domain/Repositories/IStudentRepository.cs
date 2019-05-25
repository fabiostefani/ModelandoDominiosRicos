using fabiostefani.io.PaymentContext.Domain.Entities;

namespace fabiostefani.io.PaymentContext.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubcription(Student student);
    }
}