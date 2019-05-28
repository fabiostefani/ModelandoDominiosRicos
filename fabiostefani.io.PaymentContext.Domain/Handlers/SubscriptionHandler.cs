using System;
using fabiostefani.io.PaymentContext.Domain.Commands;
using fabiostefani.io.PaymentContext.Domain.Commands.Services;
using fabiostefani.io.PaymentContext.Domain.Entities;
using fabiostefani.io.PaymentContext.Domain.Enums;
using fabiostefani.io.PaymentContext.Domain.Repositories;
using fabiostefani.io.PaymentContext.Domain.ValueObjects;
using fabiostefani.io.PaymentContext.Shared.Commands;
using fabiostefani.io.PaymentContext.Shared.Handlers;
using Flunt.Notifications;

namespace fabiostefani.io.PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, 
            IHandler<CreateBoletoSubcriptionCommand>,
            IHandler<CreatePayPalSubcriptionCommand>,
            IHandler<CreateCreditCardSubcriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;
        public SubscriptionHandler(IStudentRepository studentRepository,        
                                   IEmailService emailService)
        {
            _emailService = emailService;
            _studentRepository = studentRepository;

        }
    public ICommandResult Handle(CreateBoletoSubcriptionCommand command)
    {
        command.Validate();
        if (command.Invalid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura.");
        }

        //VERIFICAR SE DOCUMENTO JÁ ESTÁ CADASTRADO
        if (_studentRepository.DocumentExists(command.Document))
        {
            AddNotification("Document", "Esse CPF já está incluso.");
        }

        //VERIFICAR SE E-MAIL JÁ ESTÁ CADASTRADO
        if (_studentRepository.EmailExists(command.Email))
        {
            AddNotification("Email", "Esse e-mail já está incluso.");
        }

        //GERAR OS VOS
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);



        //GERAR AS ENTIDADES
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(name, document, email, address, student, subscription, payment);
        if (Invalid)
            return new CommandResult(false, "Não foi possível realizar a sua assinatura.");
            
        _studentRepository.CreateSubcription(student);
        
        _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao Fabiostefani.io", "Sua assinatura foi criada");
        
        return new CommandResult(true, "Assinatura realizada com sucesso.");
    }

        public ICommandResult Handle(CreatePayPalSubcriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            //VERIFICAR SE DOCUMENTO JÁ ESTÁ CADASTRADO
            if (_studentRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Esse CPF já está incluso.");
            }

            //VERIFICAR SE E-MAIL JÁ ESTÁ CADASTRADO
            if (_studentRepository.EmailExists(command.Email))
            {
                AddNotification("Email", "Esse e-mail já está incluso.");
            }

            //GERAR OS VOS
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);



            //GERAR AS ENTIDADES
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar a sua assinatura.");

            _studentRepository.CreateSubcription(student);
            
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao Fabiostefani.io", "Sua assinatura foi criada");
            
            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }

        public ICommandResult Handle(CreateCreditCardSubcriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            //VERIFICAR SE DOCUMENTO JÁ ESTÁ CADASTRADO
            if (_studentRepository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Esse CPF já está incluso.");
            }

            //VERIFICAR SE E-MAIL JÁ ESTÁ CADASTRADO
            if (_studentRepository.EmailExists(command.Email))
            {
                AddNotification("Email", "Esse e-mail já está incluso.");
            }

            //GERAR OS VOS
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);



            //GERAR AS ENTIDADES
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(command.CardHolderName, command.CardNumber, command.LastTransactionNumber  , command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);            
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar a sua assinatura.");

            _studentRepository.CreateSubcription(student);
            
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo ao Fabiostefani.io", "Sua assinatura foi criada");
            
            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}