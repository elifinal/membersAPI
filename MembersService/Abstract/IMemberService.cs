using Members.Contract.Contracts;

namespace MembersService.Abstract
{
    public interface IMemberService
    {
        AddMemberContract AddMember(AddMemberContract addMemberContract);
    }
}
