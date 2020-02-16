namespace Engine.Email.WithFI
{
    public class CallingClass
    {
        public void MyFunction()
        {
            FluentEmail
                .CreateEmail()
                .UsingSmtpServer("smtp host")
                .From("sender@mysite.com")
                .To("toreceiver@mysite.com")
                .CC("ccreceiver@mysite.com")
                .BCC("bccreceiver@mysite.com")
                .WithSubject("This is the subject")
                .WithBody("This is the body of the email.")
                .Send();
        }
    }
}