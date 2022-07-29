using Members.Contract.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembersDataAccess.Abstract
{
    public interface IEmailRequestRepository: IGenericRepository<EmailRequestHist>
    {
        Task<EmailRequestHist> GetMemberByEmailHistory(string email);
    }
}
