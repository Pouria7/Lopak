using Microsoft.EntityFrameworkCore;
using Lopak.Application.Interfaces;
using Lopak.Domain.Entities.Commercial;
using Lopak.Domain.Entities.Common;
using Lopak.Persistence.Configurations.Commercial;
using Lopak.Persistence.Configurations.Common;
using Lopak.Domain.Entities.UserR;
using Lopak.Persistence.Configurations.UserR;

namespace Lopak.Persistence
{
    public class LopakDbContext : DbContext, ILopakDbContext
    {
        public LopakDbContext(DbContextOptions<LopakDbContext> options)
            : base(options)
        {
          //  string c = "www";
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        //Common
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }

        //Commercial
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ActivityField> ActivityField { get; set; }
        public DbSet<ActivityTime> ActivityTime { get; set; }
        public DbSet<ValidPrice> ValidPrice { get; set; }
        public DbSet<ReceivedTrash> ReceivedTrash { get; set; }
        public DbSet<ReceivedTrashTypes> ReceivedTrashTypes { get; set; }
        public DbSet<CustomerTrashTypes> CustomerTrashTypes { get; set; }
        public DbSet<TrashType> TrashType { get; set; }

        //User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserToken> UserToken { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Common
            modelBuilder.ApplyConfiguration<Area>(new AreaConfiguration());
            modelBuilder.ApplyConfiguration<City>(new CityConfiguration());

            //Commercial
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration<ActivityField>(new ActivityFieldConfiguration());
            modelBuilder.ApplyConfiguration<ActivityTime>(new ActivityTimeConfiguration());
            modelBuilder.ApplyConfiguration<ReceivedTrash>(new ReceivedTrashConfiguration());
            modelBuilder.ApplyConfiguration<ReceivedTrashTypes>(new ReceivedTrashTypesConfiguration());
            modelBuilder.ApplyConfiguration<CustomerTrashTypes>(new CustomerTrashTypesConfiguration());
            modelBuilder.ApplyConfiguration<TrashType>(new TrashTypeConfiguration());
            modelBuilder.ApplyConfiguration<ValidPrice>(new ValidPriceConfiguration());

            //User
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Role>(new RoleConfiguration());
            modelBuilder.ApplyConfiguration<UserRole>(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration<UserToken>(new UserTokenConfiguration());

        }
    }
}
