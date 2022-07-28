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

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }


        public async Task<AddMemberContract> AddMember(AddMemberContract addMemberContract) // task içerisinde ne yazıyorsa o döner (response olarak)
        {
            try
            {
                // Email kontrolü
                var email = addMemberContract.Email;
                var emailValidation = await _memberRepository.GetMemberByEmail(addMemberContract.Email);

                if (emailValidation != null)
                {
                    throw new Exception();
                }

                var mapMember = new Member
                {
                    FirsName = addMemberContract.FirsName, // sol taraf db (new member dediğimiz için add için geçerli) ---- sağ client 
                    LastName = addMemberContract.LastName,
                    Email = addMemberContract.Email,
                    Password = addMemberContract.Password,
                    PhoneNumber = addMemberContract.PhoneNumber
                };

                await _memberRepository.AddAsync(mapMember);


                //_context.Member.Add(member);                          //// burada kullanılacak şeyleri 32 den başladık kullandık
                //await _context.SaveChangesAsync();

                //emailService.SendEmail(new EmailContent      // email service , dbde olan tablo kadar repo olur
                //                                                      concrete emailservice  abstract Iemailseervice -- controller de emailservice de yapılacak
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
