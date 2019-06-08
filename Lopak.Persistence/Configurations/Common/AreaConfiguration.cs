
using Lopak.Domain.Entities.Commercial;
using Lopak.Domain.Entities.Common;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Lopak.Persistence.Configurations.Common
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(p => p.AreaId);

            builder.Property(e => e.Title).HasMaxLength(30);
            builder.Property(e => e.TitleFa).HasMaxLength(30);

            builder.ToTable(nameof(Area), Schema.Common);

        }
    }
}
