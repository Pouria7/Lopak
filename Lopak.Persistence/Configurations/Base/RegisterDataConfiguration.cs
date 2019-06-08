using Lopak.Domain.Entities.Base;
using Lopak.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lopak.Persistence.Configurations.Base
{
    public static class RegisterDataConfiguration 
    {
        public static void Configure(EntityTypeBuilder builder)
        {
            builder.Property("CreatedDate").HasColumnType("datetime");
            builder.Property("LastUpdate").HasColumnType("datetime").HasDefaultValueSql("getdate()"); ;
        }
    }
}
