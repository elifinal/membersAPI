using Members.Contract.Data;
using MembersDataAccess.Abstract;
using MembersDataAccess.Data;

namespace MembersDataAccess.Concrete
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(DataContext context) : base(context)
        {
        }
    }
}
