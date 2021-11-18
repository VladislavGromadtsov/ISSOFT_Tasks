using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Entities;

namespace Task2.Configs
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(128);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);

            builder.Property(x => x.Surname).IsRequired().HasMaxLength(128);

            builder.HasMany(x => x.Trainings)
                .WithMany(x => x.Employees)
                .UsingEntity<EmployeeTraining>(
                r => r.HasOne<Training>().WithMany()
                .HasForeignKey(x => x.TrainingId),
                l => l.HasOne<Employee>().WithMany()
                .HasForeignKey(x => x.EmployeeId),
                join => join.ToTable("EmployeeTraining"));
        }
    }
}
