using Microsoft.EntityFrameworkCore;
using Lopak.Domain.Entities.UserR;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lopak.Persistence.Constants;

namespace Lopak.Persistence.Configurations.UserR
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Username).HasMaxLength(40).IsRequired();
            builder.HasIndex(e => e.Username).IsUnique();
           // builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.SerialNumber).HasMaxLength(450);

           // builder.HasOne

            builder.ToTable(nameof(User), Schema.User);
        }
    }
}


