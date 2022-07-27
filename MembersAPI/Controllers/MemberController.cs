using MailKit.Net.Smtp;
using MailKit.Security;
using Members.Contract.Contracts;
using MembersService.Abstract;
using MembersService.Concrete;
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
        private readonly IMemberService _memberService;

        public MemberController(DataContext context, IMemberService memberService)
        {
            _memberService=memberService;
            _context = context;

        }
        EmailService emailService = new EmailService();


        [HttpPost]
        public async Task<ActionResult> MemberAsync(AddMemberContract addMemberContract)
        {
            var result = _memberService.AddMember(addMemberContract);
            return Ok(result);
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
            var user = await _context.Member.FirstOrDefaultAsync(h => h.Email == emailContent.UserEmail);
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

                emailService.SendEmail(emailContent);
                return Ok("Email Sent");
            }

            if (resultEmailRequestHist.RequestTime.AddMinutes(1) < DateTime.Now)
            {
                resultEmailRequestHist.RequestTime = DateTime.Now;
                await _context.SaveChangesAsync();

                emailService.SendEmail(emailContent);
                return Ok("Email Sent");
            }
            else
            {
                var timeDifference = DateTime.Now - resultEmailRequestHist.RequestTime;
                return Ok((60-Convert.ToInt32(timeDifference.Seconds)).ToString() + " saniye sonra mail atılabilir");
            }

            return Ok("Email Sent");

        }










    }
}
