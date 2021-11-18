using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Entities;

namespace Task2.Configs
{
    public class TrainingConfig : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable(nameof(Training));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.Property(x => x.StartDate).HasColumnType("Date").IsRequired();
            builder.Property(x => x.EndDate).HasColumnType("Date").IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
        }
    }
}
