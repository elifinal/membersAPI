using Microsoft.EntityFrameworkCore;

namespace MembersAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Register> registers2 { get; set; }


    }
}
