using Lopak.Domain.Entities.Commercial;
using Lopak.Domain.Entities.Common;
using Lopak.Domain.Entities.UserR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lopak.Application.Interfaces
{
   public interface ILopakDbContext
    {


        //Common
         DbSet<Area> Areas { get; set; }
         DbSet<City> Cities { get; set; }

        //Commercial
         DbSet<Customer> Customers { get; set; }
         DbSet<ActivityField> ActivityField { get; set; }
         DbSet<ActivityTime> ActivityTime { get; set; }
         DbSet<ValidPrice> ValidPrice { get; set; }
         DbSet<ReceivedTrash> ReceivedTrash { get; set; }
         DbSet<ReceivedTrashTypes> ReceivedTrashTypes { get; set; }
         DbSet<CustomerTrashTypes> CustomerTrashTypes { get; set; }
         DbSet<TrashType> TrashType { get; set; }

        //User
         DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserRole> UserRole { get; set; }
         DbSet<UserToken> UserToken { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DatabaseFacade Database { get; }


    }
}
