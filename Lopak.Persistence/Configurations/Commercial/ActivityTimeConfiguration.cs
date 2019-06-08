using Lopak.Domain.Entities.Commercial;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Commercial
{
    public class ActivityTimeConfiguration : IEntityTypeConfiguration<ActivityTime>
    {
        public void Configure(EntityTypeBuilder<ActivityTime> builder)
        {
           /// builder.HasKey(p => p.ActivityTimeId);
            builder.Property(e => e.ActivityTimeId)
.HasColumnName("ActivityTimeID")
.ValueGeneratedNever();

            builder.Property(e => e.TitleFa).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Title).HasMaxLength(30);

            builder.ToTable(nameof(ActivityTime), Schema.Commercial);
        }
    }
}
