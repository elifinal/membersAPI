using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;



namespace MembersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {


        private readonly DataContext _context;

        public MemberController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> MemberAsync(Member Member)
        {
            try
            {
                _context.Member.Add(Member);
                await _context.SaveChangesAsync();
                return Ok(await _context.Member.ToListAsync());
            }
            catch (Exception e)
            {
                return Ok(e);
            }

        }

        [HttpPost("Login")]
        // login model
       // 
        public async Task<ActionResult> LoginAsync(Member member)
        {
            var checkUser = await _context.Member.FirstOrDefaultAsync(x => x.Password == member.Password && x.Email== member.Email);
            return checkUser != null ? Ok("Giriş başarılı") : BadRequest("Hatalı giriş denemesi");
        }

        //Get all users [elif]
        [HttpGet]

        public async Task<ActionResult<List<Member>>> GetUsers()
        {
            try
            {
                return Ok(await _context.Member.ToListAsync());

            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        // User search by Email [elif]
        [HttpPost("Email")]
        
        public async Task<ActionResult> SendMail(EmailContent emailContent)
        {
            var userEmail = emailContent.UserEmail ;

            var user = await _context.Member.FirstOrDefaultAsync(h => h.Email == userEmail);
            //if user exist
            if (user == null)
            {
                return StatusCode(404, "User not found.");// NotFound();
            }

            var resultEmailRequestHist = await _context.EmailRequestHist.FirstOrDefaultAsync(h => h.UserEmail == user.Email);
            
            // Kullanıcıya daha önce mail atılmamış demek.
            if (resultEmailRequestHist == null)
            {
                EmailRequestHist emailrequestHist = new EmailRequestHist()
                {
                    RequestTime = DateTime.Now,
                    UserEmail = user.Email,
                };
                _context.EmailRequestHist.Add(emailrequestHist);
                await _context.SaveChangesAsync();
                return Ok("Email Sent");
            }
            
            if (resultEmailRequestHist.RequestTime.AddMinutes(1)< DateTime.Now)
            {
                resultEmailRequestHist.RequestTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok("Email Sent");
            }
            else
            {   
                var timeDifference = DateTime.Now - resultEmailRequestHist.RequestTime;
                return Ok((60-Convert.ToInt32(timeDifference.Seconds)).ToString() + " saniye sonra mail atılabilir");    
            }
            
            return Ok("Email Sent");
            //var user = await _context.Member.FirstOrDefaultAsync(h => h.Email == Email);
            ////if user exist
            //if (user == null)
            //    return StatusCode(404, "User not found.");// NotFound();

            

            //try
            //{
            //    var email = new MimeKit.MimeMessage();
            //    email.From.Add(MailboxAddress.Parse("jacques98@ethereal.email"));
            //    email.To.Add(MailboxAddress.Parse("jacques98@ethereal.email"));
            //    email.Subject = "Test deneme birki";
            //    email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "asffsd" };

            //    using var smtp = new SmtpClient();
            //    smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            //    smtp.Authenticate("jacques98@ethereal.email", "M2ggAjXZDP1pbzme1z");
            //    smtp.Send(email);
            //    smtp.Disconnect(true);
            //}

        }










    }
}
