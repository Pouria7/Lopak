using System;
using System.Collections.Generic;
using System.Linq;
using Lopak.Domain.Entities;
using Lopak.Domain.Entities.Commercial;
using Lopak.Domain.Entities.Common;
using Lopak.Domain.Entities.UserR;

namespace Lopak.Persistence
{
    public class LopakInitializer
    {
        //private readonly Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();
        //private readonly Dictionary<int, Supplier> Suppliers = new Dictionary<int, Supplier>();
        //private readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();
        //private readonly Dictionary<int, Shipper> Shippers = new Dictionary<int, Shipper>();
        //private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();

        public static void Initialize(LopakDbContext context)
        {
            var initializer = new LopakInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(LopakDbContext context)
        {
            //context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return; // Db has been seeded
            }

             SeedRoles(context);
             SeedTrashTypes(context);

             SeedCities(context);
             SeedAreas(context);
             SeedActivityFields(context);
             SeedActivityTimes(context);
        }

         public void SeedRoles(LopakDbContext context)
        {
            var roles = new[]
            {
               new Role(){RoleId = 1,Name = "SuperAdmin"},  new Role(){RoleId = 2,Name = "Admin"},
               new Role(){RoleId = 3,Name = "Support"},  new Role(){RoleId = 4,Name = "Warehouseman"},
               new Role(){RoleId = 5,Name = "Commercial"},  new Role(){RoleId = 6,Name = "Personal"},
               new Role(){RoleId = 7,Name = "Driver"},
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }

        public void SeedTrashTypes(LopakDbContext context)
        {
            var trashTypes = new[]
            {
                new TrashType(){TrashTypeId = 1, Title = "Plastic", TitleFa ="پلاستیک"},
                new TrashType(){TrashTypeId = 2, Title = "Aluminium", TitleFa ="آلومینیوم"},
                new TrashType(){TrashTypeId = 3, Title = "Glass", TitleFa ="شیشه"},
                new TrashType(){TrashTypeId = 4, Title = "Bread", TitleFa ="نان"},
            };

            context.TrashType.AddRange(trashTypes);
            context.SaveChanges();
        }

        public void SeedCities(LopakDbContext context)
        {
            var cities = new[]
            {
                new City(){CityId = 1,Title = "Tehran", TitleFa ="تهران" }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }

        public void SeedAreas(LopakDbContext context)
        {
            var areas = new[]
            {
                new Area(){CityId = 1, TitleFa ="منطقه 1" },
                new Area(){CityId = 1, TitleFa ="منطقه 2" },
                new Area(){CityId = 1, TitleFa ="منطقه 3" },
                new Area(){CityId = 1, TitleFa ="منطقه 4" }
            };

            context.Areas.AddRange(areas);
            context.SaveChanges();
        }

        public void SeedActivityFields(LopakDbContext context)
        {
            var activityFields = new[]
             {
                new ActivityField(){ActivityFieldId = 1,Title = "Super Market", TitleFa ="سوپرمارکت" },
                new ActivityField(){ActivityFieldId = 2,Title = "Fast Food", TitleFa ="فست فود" },
                new ActivityField(){ActivityFieldId = 3,Title = "Restaurant", TitleFa ="رستوران" }
            };
            context.ActivityField.AddRange(activityFields);
            context.SaveChanges();
        }
        public void SeedActivityTimes(LopakDbContext context)
        {
            var activityTimes = new[]
            {
                new ActivityTime(){ActivityTimeId = 1,Title = "", TitleFa = "ساعت 9 تا 12 صبح" },
                 new ActivityTime(){ActivityTimeId = 2,Title = "", TitleFa = "ساعت 16 تا 20 بعداز ظهر" }
            };

            context.ActivityTime.AddRange(activityTimes);
            context.SaveChanges();
        }

    }
}