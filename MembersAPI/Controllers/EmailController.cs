using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MembersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMail(string body)
        {
            var email = new MimeKit.MimeMessage();
            email.From.Add(MailboxAddress.Parse("jacques98@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("jacques98@ethereal.email"));
            email.Subject = "Test deneme birki";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("jacques98@ethereal.email", "M2ggAjXZDP1pbzme1z");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();

        }
    }
}
