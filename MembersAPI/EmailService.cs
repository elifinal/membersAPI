using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MembersAPI
{
    public class EmailService // EmailService
    {
        public void SendEmail(EmailContent emailContent)
        {
            PrivateSendEmail(new EmailContract
            {
                To=emailContent.UserEmail,
                Body=emailContent.Body,
                Subject=emailContent.Title,
            });

        }

        private void PrivateSendEmail(EmailContract emailContract)
        {
            var email = new MimeKit.MimeMessage();
            email.From.Add(MailboxAddress.Parse("ray56@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(emailContract.To));
            email.Subject = emailContract.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailContract.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ray56@ethereal.email", "zBkxtfY2URTFDwnpEQ");
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
