using Members.Contract.Contracts;
using MembersDataAccess.Abstract;
using MembersDataAccess.Data;
using MembersService.Abstract;

namespace MembersService.Concrete
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository=memberRepository;
        }


        public async Task<AddMemberContract> AddMember(AddMemberContract addMemberContract)
        {
            try
            {
                // Email kontrolü
                var email = addMemberContract.Email;
                var emailValidation = await _memberRepository.FindByAsync(m => m.Email== addMemberContract.Email);

                if (emailValidation != null)
                {
                    // return Ok("Bu Email kullanılmakta");
                }


                //_context.Member.Add(member);
                //await _context.SaveChangesAsync();

                //emailService.SendEmail(new EmailContent
                //{
                //    UserEmail=email,
                //    Title="Test Title",
                //    Body="Test Body"
                //});

                //return Ok("User Saved New User Mail Sended");

            }
            catch (Exception e)
            {
                //  return Ok(e);
            }

            return addMemberContract;
        }
    }
}
