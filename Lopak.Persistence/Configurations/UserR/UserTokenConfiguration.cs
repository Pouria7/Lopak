using Lopak.Domain.Entities.UserR;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.UserR
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
           // builder.HasKey(p => p.Id);

            builder.Property(p => p.RemoteIpAddress).HasMaxLength(45);


            builder.ToTable(nameof(UserToken), Schema.User);
        }
    }
}
