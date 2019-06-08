using Lopak.Domain.Entities.Commercial;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Commercial
{
    public class ActivityFieldConfiguration : IEntityTypeConfiguration<ActivityField>
    {
        public void Configure(EntityTypeBuilder<ActivityField> builder)
        {
           /// builder.HasKey(p => p.ActivityFieldId);
            builder.Property(e => e.ActivityFieldId)
.HasColumnName("ActivityFieldID")
.ValueGeneratedNever();

            builder.Property(e => e.TitleFa).HasMaxLength(30).IsRequired();
            builder.Property(e => e.Title).HasMaxLength(30);

            builder.ToTable(nameof(ActivityField), Schema.Commercial);
        }
    }
}
