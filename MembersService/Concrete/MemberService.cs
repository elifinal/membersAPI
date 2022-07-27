using Members.Contract.Contracts;
using MembersService.Abstract;

namespace MembersService.Concrete
{
    public class MemberService : IMemberService
    {
        public AddMemberContract AddMember(AddMemberContract addMemberContract)
        {
            try
            {
                // Email kontrolü
                var email = addMemberContract.Email;
                var emailValidation = string.Empty;// await _context.Member.FirstOrDefaultAsync(x => x.Email == email);

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
