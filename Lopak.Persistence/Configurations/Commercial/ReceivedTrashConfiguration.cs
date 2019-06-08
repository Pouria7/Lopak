using Lopak.Domain.Entities.Commercial;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Commercial
{
    public class ReceivedTrashConfiguration : IEntityTypeConfiguration<ReceivedTrash>
    {
        public void Configure(EntityTypeBuilder<ReceivedTrash> builder)
        {
            builder.HasKey(p => p.ReceivedTrashId);

            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.ReceivedTrashs)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Customer_ReceivedTrashs");

            builder.HasOne(d => d.ActivityTime)
                .WithMany(d => d.ReceivedTrash)
                .HasForeignKey(d => d.ReceivedTrashId)
                .HasConstraintName("FK_ActivityTime_ReceivedTrashs");


            Base.RegisterDataConfiguration.Configure(builder);

            builder.ToTable(nameof(ReceivedTrash), Schema.Commercial);
        }
    }
}
