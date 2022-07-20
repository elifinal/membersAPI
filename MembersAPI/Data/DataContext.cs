using Microsoft.EntityFrameworkCore;

namespace MembersAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }



        public DbSet<SuperHero> superHeroes { get; set; }
        public DbSet<Register> registers { get; set; }


    }
}
