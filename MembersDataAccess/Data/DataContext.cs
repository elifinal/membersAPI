using Members.Contract.Data;
using Microsoft.EntityFrameworkCore;

namespace MembersDataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Member> Member { get; set; }
        public DbSet<EmailRequestHist> EmailRequestHist { get; set; }


    }
}
