using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Members.Contract;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MembersService.Abstract;

namespace MembersService.Concrete
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailContract emailContract) 
        {
            PrivateSendEmail(new EmailContract
            {
                To=emailContract.To,
                Body=emailContract.Body,
                Subject=emailContract.Subject
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
