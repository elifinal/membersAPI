using Members.Contract.Data;
using MembersDataAccess.Abstract;
using MembersDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembersDataAccess.Concrete
{
    public class EmailRequestRepository : GenericRepository<EmailRequestHist>, IEmailRequestRepository
    {
        private readonly DbSet<EmailRequestHist> _dbSet;

        public EmailRequestRepository(DataContext dataContext) : base(dataContext)
        {
            _dbSet=dataContext.Set<EmailRequestHist>(); ;
        }

        public async Task<EmailRequestHist> GetMemberByEmailHistory(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.UserEmail==email);
        }
    }
}
