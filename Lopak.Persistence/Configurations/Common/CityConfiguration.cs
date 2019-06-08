
using Lopak.Domain.Entities.Commercial;
using Lopak.Domain.Entities.Common;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Lopak.Persistence.Configurations.Common
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
           /// builder.HasKey(p => p.CityId);
            builder.Property(e => e.CityId)
.HasColumnName("CityID")
.ValueGeneratedNever();

            builder.Property(e => e.Title).HasMaxLength(50);
            builder.Property(e => e.TitleFa).HasMaxLength(50).IsRequired();

            builder.HasMany(d => d.Areas)
                .WithOne(p => p.City)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_City_Areas");

            builder.ToTable(nameof(City), Schema.Common);
        }
    }
}
