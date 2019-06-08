using Lopak.Domain.Entities.Commercial;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Commercial
{
    public class TrashTypeConfiguration : IEntityTypeConfiguration<TrashType>
    {
        public void Configure(EntityTypeBuilder<TrashType> builder)
        {
           /// builder.HasKey(p => p.TrashTypeId);
            builder.Property(e => e.TrashTypeId)
.HasColumnName("TrashTypeD")
.ValueGeneratedNever();

            builder.Property(e => e.TitleFa).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Title).HasMaxLength(30);


            builder.ToTable(nameof(TrashType), Schema.Commercial);

        }
    }
}
