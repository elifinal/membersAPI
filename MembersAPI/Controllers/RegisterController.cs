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
        public async Task<ActionResult> LoginAsync(Member Member)
        {
            var checkUser = await _context.Set<Member>().FirstOrDefaultAsync(x => x.Password == Member.Password);

            return null;
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
        [HttpGet("Email")]
        
        public async Task<ActionResult<Member>> GetUser(string Email)
        {
            var user = await _context.Member.FirstOrDefaultAsync(h => h.Email == Email);
            //if user exist
            if (user == null)
                return StatusCode(404, "User not found.");// NotFound();

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

            return Ok();
        }










    }
}
