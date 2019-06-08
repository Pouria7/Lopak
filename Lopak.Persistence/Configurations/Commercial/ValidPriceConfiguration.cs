using Lopak.Domain.Entities.Commercial;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Commercial
{
    public class ValidPriceConfiguration : IEntityTypeConfiguration<ValidPrice>
    {
        public void Configure(EntityTypeBuilder<ValidPrice> builder)
        {
            builder.HasKey(p => p.ValidPriceId);

            builder.Property(e => e.Date).HasColumnType("datetime").IsRequired();

            builder.Property(e => e.Price).HasColumnType("bigint");
     
            builder.HasOne(d => d.City)
                .WithMany(b => b.ValidPrices)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_ValidPrices_City");


            builder.ToTable(nameof(ValidPrice), Schema.Commercial);

        }
    }
}
