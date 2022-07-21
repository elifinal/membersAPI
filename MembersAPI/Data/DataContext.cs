using Microsoft.EntityFrameworkCore;

namespace MembersAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Member> Member { get; set; }


    }
}
