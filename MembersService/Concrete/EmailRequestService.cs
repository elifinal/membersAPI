using Members.Contract;
using MembersDataAccess.Abstract;
using MembersDataAccess.Concrete;
using MembersService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembersService.Concrete
{
    public class EmailRequestService : IEmailRequestService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IEmailRequestRepository _emailRequestRepository;

        public EmailRequestService(IMemberRepository memberRepository, IEmailRequestRepository emailRequestRepository)
        {
            _memberRepository=memberRepository;
            _emailRequestRepository=emailRequestRepository;
        }

        public async Task<EmailContract> SendMail(EmailContract emailContract)
        {
            var user = await _memberRepository.GetMemberByEmail(emailContract.To);
            //if user exist
            if (user == null)
            {
                return emailContract;// NotFound();
            }

            var resultEmailRequestHist = await _emailRequestRepository.GetMemberByEmailHistory(emailContract.To);

            // Kullanıcıya daha önce mail atılmamış demek.
            if (resultEmailRequestHist == null)
            {
                _emailRequestRepository.

                EmailRequestHist emailrequestHist = new EmailRequestHist()
                {
                    RequestTime = DateTime.Now,
                    UserEmail = user.Email,
                };
                _context.EmailRequestHist.Add(emailrequestHist);
                await _context.SaveChangesAsync();

                emailService.SendEmail(emailContent);
                return Ok("Email Sent");

                _emailService.SendEmail(new EmailContract
                {
                    To=email,
                    Subject="Test Title",
                    Body="Test Body"
                });
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