using Microsoft.EntityFrameworkCore;

namespace SolarTask
{
    public class BirthdayDbContext : DbContext
    {
        public BirthdayDbContext() => Database.EnsureCreated();
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Data.db");
        }





    }
}
