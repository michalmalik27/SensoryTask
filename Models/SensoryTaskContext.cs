using Microsoft.EntityFrameworkCore;

namespace SensoryTask.Models
{
    public class SensoryTaskContext : DbContext
    {
        public SensoryTaskContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Profession> Professions { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profession>().HasData(new Profession
            {
                ProfessionId = 1,
                ProfessionName = "Unemployed",
            }, new Profession
            {
                ProfessionId = 2,
                ProfessionName = "Programmer",
            }, new Profession
            {
                ProfessionId = 3,
                ProfessionName = "Gardener",
            }, new Profession
            {
                ProfessionId = 4,
                ProfessionName = "Teacher",
            }, new Profession
            {
                ProfessionId = 5,
                ProfessionName = "Cashier",
            });
        }
    }
}
