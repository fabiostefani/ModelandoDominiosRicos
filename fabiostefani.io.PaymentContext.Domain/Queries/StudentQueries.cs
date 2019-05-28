using System;
using System.Linq.Expressions;
using fabiostefani.io.PaymentContext.Domain.Entities;

namespace fabiostefani.io.PaymentContext.Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudentInfo(string document)
        {
            return x => x.Document.Number == document;
            
        }
    }
}