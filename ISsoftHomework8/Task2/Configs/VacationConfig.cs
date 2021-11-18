using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Entities;

namespace Task2.Configs
{
    public class VacationConfig : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.ToTable(nameof(Vacation));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartDate).HasColumnType("Date");
            builder.Property(x => x.EndDate).HasColumnType("Date");

            builder.HasOne(x => x.Employee).WithMany(x => x.Vacations).HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
