using System.Collections.Generic;
using System.Net.Mail;

namespace Engine.Email.WithFI
{
    public class FluentEmail :
        ICanSetSmtpServer, ICanSetFromAddress, ICanAddInitialToAddress,
        ICanAddAnotherReceiverOrSubject, ICanAddBody, ICanSend
    {
        private readonly bool _isHtml;
        private string _smtpServer;
        private MailAddress _fromAddress;
        private readonly List<MailAddress> _toAddresses = new List<MailAddress>();
        private readonly List<MailAddress> _bccAddresses = new List<MailAddress>();
        private readonly List<MailAddress> _ccAddresses = new List<MailAddress>();
        private string _subject;
        private string _body;

        private FluentEmail(bool isHtml)
        {
            _isHtml = isHtml;
        }

        // Initiating function(s)
        public static ICanSetSmtpServer CreateEmail()
        {
            FluentEmail emailHelper = new FluentEmail(false);
            return emailHelper;
        }

        public static ICanSetSmtpServer CreateHtmlEmail()
        {
            FluentEmail emailHelper = new FluentEmail(true);
            return emailHelper;
        }

        // Chaining function(s)
        public ICanSetFromAddress UsingSmtpServer(string smtpServer)
        {
            _smtpServer = smtpServer;
            return this;
        }

        public ICanAddInitialToAddress From(string senderEmailAddress)
        {
            _fromAddress = new MailAddress(senderEmailAddress);
            return this;
        }

        public ICanAddInitialToAddress From(string senderEmailAddress, string senderName)
        {
            _fromAddress = new MailAddress(senderEmailAddress, senderName);
            return this;
        }

        public ICanAddInitialToAddress From(string senderEmailAddress, string senderName, System.Text.Encoding encoding)
        {
            _fromAddress = new MailAddress(senderEmailAddress, senderName, encoding);
            return this;
        }

        public ICanAddAnotherReceiverOrSubject To(string toEmailAddress)
        {
            _toAddresses.Add(new MailAddress(toEmailAddress));
            return this;
        }

        public ICanAddAnotherReceiverOrSubject To(string toEmailAddress, string toName)
        {
            _toAddresses.Add(new MailAddress(toEmailAddress, toName));
            return this;
        }

        public ICanAddAnotherReceiverOrSubject To(string toEmailAddress, string toName, System.Text.Encoding encoding)
        {
            _toAddresses.Add(new MailAddress(toEmailAddress, toName, encoding));
            return this;
        }

        public ICanAddAnotherReceiverOrSubject CC(string ccEmailAddress)
        {
            _ccAddresses.Add(new MailAddress(ccEmailAddress));
            return this;
        }

        public ICanAddAnotherReceiverOrSubject CC(string ccEmailAddress, string ccName)
        {
            _ccAddresses.Add(new MailAddress(ccEmailAddress, ccName));
            return this;
        }

        public ICanAddAnotherReceiverOrSubject CC(string ccEmailAddress, string ccName, System.Text.Encoding encoding)
        {
            _ccAddresses.Add(new MailAddress(ccEmailAddress, ccName, encoding));
            return this;
        }

        public ICanAddAnotherReceiverOrSubject BCC(string bccEmailAddress)
        {
            _bccAddresses.Add(new MailAddress(bccEmailAddress));
            return this;
        }

        public ICanAddAnotherReceiverOrSubject BCC(string bccEmailAddress, string bccName)
        {
            _bccAddresses.Add(new MailAddress(bccEmailAddress, bccName));
            return this;
        }

        public ICanAddAnotherReceiverOrSubject BCC(string bccEmailAddress, string bccName, System.Text.Encoding encoding)
        {
            _bccAddresses.Add(new MailAddress(bccEmailAddress, bccName, encoding));
            return this;
        }

        public ICanAddBody WithSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public ICanSend WithBody(string body)
        {
            _body = body;
            return this;
        }

        // Ending function(s)
        public void Send()
        {
            MailMessage email =
                new MailMessage
                {
                    From = _fromAddress,
                    IsBodyHtml = _isHtml
                };

            foreach(MailAddress toAddress in _toAddresses)
            {
                email.To.Add(toAddress);
            }

            foreach(MailAddress ccAddress in _ccAddresses)
            {
                email.To.Add(ccAddress);
            }

            foreach(MailAddress bccAddress in _bccAddresses)
            {
                email.To.Add(bccAddress);
            }

            email.Subject = _subject;
            email.Body = _body;

            SmtpClient smtpClient = new SmtpClient(_smtpServer);
            smtpClient.Send(email);
        }
    }

    #region Interfaces

    public interface ICanSetSmtpServer
    {
        ICanSetFromAddress UsingSmtpServer(string smtpServer);
    }

    public interface ICanSetFromAddress
    {
        ICanAddInitialToAddress From(string senderEmailAddress);
        ICanAddInitialToAddress From(string senderEmailAddress, string senderName);
        ICanAddInitialToAddress From(string senderEmailAddress, string senderName, System.Text.Encoding encoding);
    }

    public interface ICanAddInitialToAddress
    {
        ICanAddAnotherReceiverOrSubject To(string toEmailAddress);
        ICanAddAnotherReceiverOrSubject To(string toEmailAddress, string toName);
        ICanAddAnotherReceiverOrSubject To(string toEmailAddress, string toName, System.Text.Encoding encoding);
    }

    public interface ICanAddAnotherReceiverOrSubject : ICanAddSubject
    {
        ICanAddAnotherReceiverOrSubject To(string toEmailAddress);
        ICanAddAnotherReceiverOrSubject To(string toEmailAddress, string toName);
        ICanAddAnotherReceiverOrSubject To(string toEmailAddress, string toName, System.Text.Encoding encoding);
        ICanAddAnotherReceiverOrSubject CC(string ccEmailAddress);
        ICanAddAnotherReceiverOrSubject CC(string ccEmailAddress, string ccName);
        ICanAddAnotherReceiverOrSubject CC(string toEmailAddress, string toName, System.Text.Encoding encoding);
        ICanAddAnotherReceiverOrSubject BCC(string bccEmailAddress);
        ICanAddAnotherReceiverOrSubject BCC(string bccEmailAddress, string bccName);
        ICanAddAnotherReceiverOrSubject BCC(string toEmailAddress, string toName, System.Text.Encoding encoding);
    }

    public interface ICanAddSubject
    {
        ICanAddBody WithSubject(string subject);
    }

    public interface ICanAddBody
    {
        ICanSend WithBody(string body);
    }

    public interface ICanSend
    {
        void Send();
    }

    #endregion
} 