using Members.Contract.Data;

namespace MembersDataAccess.Abstract
{
    public interface IMemberRepository: IGenericRepository<Member>
    {
        Task<Member> GetMemberByEmail(string email);
    }
}
