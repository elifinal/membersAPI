using Members.Contract.Contracts;

namespace MembersService.Abstract
{
    public interface IMemberService
    {
        Task<AddMemberContract> AddMember(AddMemberContract addMemberContract);
    }
}
