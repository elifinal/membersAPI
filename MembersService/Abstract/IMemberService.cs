using Members.Contract.Contracts;
using Members.Contract.Data;

namespace MembersService.Abstract
{
    public interface IMemberService
    {
        Task<AddMemberContract> AddMember(AddMemberContract addMemberContract);
        Task<List<Member>> GetAllMembers();
    }
}
