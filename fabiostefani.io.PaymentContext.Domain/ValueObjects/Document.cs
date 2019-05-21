using fabiostefani.io.PaymentContext.Domain.Enums;
using fabiostefani.io.PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace fabiostefani.io.PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Name", "Documento inválido")
            );

        }
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate()
        {
            //lógica de validação de documento
            //SOMENTE EXPRESSANDO A IDEIA DE VALIDAÇÃO
            if (Type == EDocumentType.CNPJ && Number.Length == 14)
                return true;

            if (Type == EDocumentType.CPF && Number.Length == 11)
                return true;
            
            return false;
        }
    }
}