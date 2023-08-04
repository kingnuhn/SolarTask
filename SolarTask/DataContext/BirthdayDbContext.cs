using Microsoft.EntityFrameworkCore;
using SolarTask.Model;

namespace SolarTask.DataContext
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
