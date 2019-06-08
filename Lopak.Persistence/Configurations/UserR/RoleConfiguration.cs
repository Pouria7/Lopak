using Lopak.Domain.Entities.UserR;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.UserR
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
          ///  builder.HasKey(p => p.RoleId);
            builder.Property(e => e.RoleId)
      .HasColumnName("RoleID")
      .ValueGeneratedNever();


            builder.Property(e => e.Name).HasMaxLength(450).IsRequired();
            builder.HasIndex(e => e.Name).IsUnique();

            builder.ToTable(nameof(Role), Schema.User);
        }
    }
}
