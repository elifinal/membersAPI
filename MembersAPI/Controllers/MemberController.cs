using Members.Contract;
using Members.Contract.Contracts;
using Members.Contract.Data;
using MembersService.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;

namespace MembersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {


        private readonly IMemberService _memberService;
        private readonly MembersService.Abstract.IEmailService _emailService;
        private readonly IEmailRequestService _emailRequestService;


        public MemberController(IMemberService memberService, MembersService.Abstract.IEmailService emailService, IEmailRequestService emailRequestService)
        {
            _memberService = memberService;
            _emailService=emailService;
            _emailRequestService=emailRequestService;
        }


        [HttpPost]
        public async Task<ActionResult> MemberAsync(AddMemberContract addMemberContract)
        {
            var result = await _memberService.AddMember(addMemberContract);
            return Ok(result);
        }

        [HttpPost("Login")]
        // login model
        // 
        public async Task<ActionResult> LoginAsync(LoginContract loginContract)
        {
            //var checkUser = await _context.Member.FirstOrDefaultAsync(x => x.Password == member.Password && x.Email== member.Email);
            //return checkUser != null ? Ok("Giriş başarılı") : BadRequest("Hatalı giriş denemesi");
            return Ok(loginContract);
        }

        //Get all users [elif]
        [HttpGet("Members")]

        public async Task<ActionResult<List<Member>>> GetMembers()
        {
            return await _memberService.GetAllMembers();
        }

        // User search by Email [elif]
        [HttpPost("Email")]

        public async Task<ActionResult> SendMail(EmailContract emailContract)
        {
            var res = await _emailRequestService.SendMailToMember(emailContract);
            return Ok(res);

            //var user = await _context.Member.FirstOrDefaultAsync(h => h.Email == emailContent.UserEmail);
            ////if user exist
            //if (user == null)
            //{
            //    return StatusCode(404, "User not found.");// NotFound();
            //}

            //var resultEmailRequestHist = await _context.EmailRequestHist.FirstOrDefaultAsync(h => h.UserEmail == user.Email);

            //// Kullanıcıya daha önce mail atılmamış demek.
            //if (resultEmailRequestHist == null)
            //{
            //    EmailRequestHist emailrequestHist = new EmailRequestHist()
            //    {
            //        RequestTime = DateTime.Now,
            //        UserEmail = user.Email,
            //    };
            //    _context.EmailRequestHist.Add(emailrequestHist);
            //    await _context.SaveChangesAsync();

            //    emailService.SendEmail(emailContent);
            //    return Ok("Email Sent");
            //}

            //if (resultEmailRequestHist.RequestTime.AddMinutes(1) < DateTime.Now)
            //{
            //    resultEmailRequestHist.RequestTime = DateTime.Now;
            //    await _context.SaveChangesAsync();

            //    emailService.SendEmail(emailContent);
            //    return Ok("Email Sent");
            //}
            //else
            //{
            //    var timeDifference = DateTime.Now - resultEmailRequestHist.RequestTime;
            //    return Ok((60-Convert.ToInt32(timeDifference.Seconds)).ToString() + " saniye sonra mail atılabilir");
            //}

            //return Ok("Email Sent");

        }










    }
}
