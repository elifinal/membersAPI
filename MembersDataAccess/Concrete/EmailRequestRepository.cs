using Members.Contract.Data;
using MembersDataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembersDataAccess.Concrete
{
    public class EmailRequestRepository : IEmailRequestRepository
    {
        private readonly DbSet<EmailRequestHist> _dbSet;

        public EmailRequestRepository(DbSet<EmailRequestHist> dbSet)
        {
            _dbSet=dbSet;
        }

        public async Task<EmailRequestHist> GetMemberByEmailHistory(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.UserEmail==email);
        }
    }
}
