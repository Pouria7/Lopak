using Lopak.Domain.Entities.Commercial;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Commercial
{
    public class CustomerTrashTypesConfiguration : IEntityTypeConfiguration<CustomerTrashTypes>
    {
        public void Configure(EntityTypeBuilder<CustomerTrashTypes> builder)
        {
            builder.HasKey(x => new { x.CustomerId, x.TrashTypeId });

            builder.HasOne(d => d.Customer)
                .WithMany(b => b.CustomerTrashTypes)
                .HasForeignKey(d => d.CustomerId);

            builder.HasOne(d => d.TrashType)
               .WithMany(b => b.CustomerTrashTypes)
               .HasForeignKey(d => d.TrashTypeId);


            builder.ToTable(nameof(CustomerTrashTypes), Schema.Commercial);
        }
    }
}
