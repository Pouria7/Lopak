using Lopak.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lopak.Persistence
{
    public class LopakContextFactory : DesignTimeDbContextFactoryBase<LopakDbContext>
    {
        protected override LopakDbContext CreateNewInstance(DbContextOptions<LopakDbContext> options)
        {
            return new LopakDbContext(options);
        }
    }
}
