using Members.Contract.Data;
using MembersDataAccess.Abstract;
using MembersDataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace MembersDataAccess.Concrete
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly DbSet<Member> _dbSet;
        public MemberRepository(DataContext context) : base(context)
        {
            _dbSet = context.Set<Member>();
        }

        public async Task<Member> GetMemberByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Email==email);
        }
    }
}
