using Members.Contract;
using Members.Contract.Contracts;
using Members.Contract.Data;
using MembersDataAccess.Abstract;
using MembersDataAccess.Data;
using MembersService.Abstract;

namespace MembersService.Concrete
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IEmailService _emailService;

        public MemberService(IMemberRepository memberRepository, IEmailService emailService)
        {
            _memberRepository=memberRepository;
            _emailService=emailService;
        }


        public async Task<AddMemberContract> AddMember(AddMemberContract addMemberContract)
        {
            try
            {
                // Email kontrolü
                var email = addMemberContract.Email;
                var emailValidation = await _memberRepository.GetMemberByEmail(addMemberContract.Email);

                if (emailValidation != null)
                {
                    // return Ok("Bu Email kullanılmakta");
                }

                var member = new Member()
                {
                    Email = addMemberContract.Email,
                    FirsName = addMemberContract.FirsName,
                    LastName = addMemberContract.LastName,
                    Password = addMemberContract.Password,
                    PhoneNumber = addMemberContract.PhoneNumber

                };



                var result = await _memberRepository.AddAsync(member);

                _emailService.SendEmail(new EmailContract
                {
                    To=email,
                    Subject="Test Title",
                    Body="Test Body"
                });
                
                 // yeni kontrakt tanıml

            }
            catch (Exception e)
            {
                //  return Ok(e);
            }

            return addMemberContract;
        }

        public async Task<List<Member>> GetAllMembers()
        {
            var data = await _memberRepository.GetAllAsync();
            return data.ToList();
        }
    }
}
