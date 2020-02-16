using System.Net.Mail;

namespace Engine.Email.WithoutFI
{
    public class CallingClass
    {
        public void MyFunction()
        {
            MailMessage email = new MailMessage();

            email.From = new MailAddress("sender@mysite.com");

            email.To.Add("toreceiver@mysite.com");
            email.CC.Add("ccreceiver@mysite.com");
            email.Bcc.Add("bccreceiver@mysite.com");

            email.Subject = "This is the subject";

            email.Body = "This is the body of the email.";

            SmtpClient smtpClient = new SmtpClient("smtp host");
            smtpClient.Send(email);
        }
    }
}
