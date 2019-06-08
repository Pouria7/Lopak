using Lopak.Domain.Entities.UserR;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.UserR
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => new { e.UserId, e.RoleId });
            builder.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
            builder.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);

            builder.ToTable(nameof(UserRole), Schema.User);
        }
    }
}
