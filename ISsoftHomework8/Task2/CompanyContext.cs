using Microsoft.EntityFrameworkCore;
using Task2.Configs;
using Task2.Entities;

namespace Task2
{
    public class CompanyContext : DbContext
    {
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public CompanyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainingConfig());
            modelBuilder.ApplyConfiguration(new VacationConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
        }
    }
}
