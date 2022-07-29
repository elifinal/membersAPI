using Members.Contract;
using Members.Contract.Data;
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
        private readonly IEmailService _emailService;

        public EmailRequestService(IMemberRepository memberRepository, IEmailRequestRepository emailRequestRepository, IEmailService emailService )
        {
            _memberRepository=memberRepository;
            _emailRequestRepository=emailRequestRepository;
            _emailService=emailService;
        }

        public async Task<EmailContract> SendMailToMember(EmailContract emailContract)
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
                await _emailRequestRepository.AddAsync(new EmailRequestHist
                {
                    RequestTime = DateTime.Now,
                    UserEmail = user.Email
                });
                _emailService.SendEmail(emailContract);
                return emailContract;
            }

            if (resultEmailRequestHist.RequestTime.AddMinutes(1) < DateTime.Now)
            {
                resultEmailRequestHist.RequestTime = DateTime.Now;
                await _emailRequestRepository.UpdateAsync(resultEmailRequestHist);
                _emailService.SendEmail(emailContract);
                return emailContract;
            }
            else
            {
                var timeDifference = DateTime.Now - resultEmailRequestHist.RequestTime;
                var res = (60-Convert.ToInt32(timeDifference.Seconds)).ToString();

                return emailContract;
            }

        }
    }
}