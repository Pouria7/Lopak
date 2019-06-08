using Lopak.Domain.Entities.Commercial;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Commercial
{
    public class ReceivedTrashTypesConfiguration : IEntityTypeConfiguration<ReceivedTrashTypes>
    {
        public void Configure(EntityTypeBuilder<ReceivedTrashTypes> builder)
        {
            builder.HasKey(x => new { x.ReceivedTrashId, x.TrashTypeId });

            builder.HasOne(d => d.ReceivedTrash)
                .WithMany(b => b.ReceivedTrashTypes)
                .HasForeignKey(d => d.ReceivedTrashId);

            builder.HasOne(d => d.TrashType)
               .WithMany(b => b.ReceivedTrashTypes)
               .HasForeignKey(d => d.TrashTypeId);


            builder.Property(e => e.Price).HasColumnType("bigint");

            builder.ToTable(nameof(ReceivedTrashTypes), Schema.Commercial);
        }
    }
}
