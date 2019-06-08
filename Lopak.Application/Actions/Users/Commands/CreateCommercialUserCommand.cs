using Lopak.Application.Exceptions;
using Lopak.Application.Helper;
using Lopak.Application.Infrastructure;
using Lopak.Application.Interfaces;
using Lopak.Domain.Entities.Commercial;
using Lopak.Domain.Entities.UserR;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lopak.Application.Actions.Users.Commands
{
   public class CreateCommercialUserCommand : IRequest<CommandActionResult>
    {
        public string CellPhone { get; set; }
        public string Password { get; set; }

        public string ContactTitle { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        //Location
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int AreaId { get; set; }
        public int ActivityFieldId { get; set; }
        public List<TrashTypeViewModel> TrashTypes { get; set; }

        public class Handler : IRequestHandler<CreateCommercialUserCommand, CommandActionResult>
        {
            private readonly ILopakDbContext _context;

            public Handler(ILopakDbContext context)
            {
                _context = context;
            }

            public async Task<CommandActionResult> Handle(CreateCommercialUserCommand request, CancellationToken cancellationToken)
            {

                var Result = new CommandActionResult();


                string username = request.CellPhone;

                if (_context.Users.Any(x => x.Username == username))
                    throw new CustomException("Username: \"" + username + "\" is already taken");


                byte[] passwordHash, passwordSalt;
                EncryptTools.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                var user = new User()
                {
                    Username = username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    DisplayName = request.ContactName,
                    //Default User Active
                    IsActive = true
                };  
             
                    using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        user.UserRoles.Add(new UserRole() { RoleId = 5 });

                        await _context.Users.AddAsync(user);
                        await _context.SaveChangesAsync(cancellationToken);

                        var customer = new Customer()
                        {
                            CustomerId = request.CellPhone,
                            UserId = user.Id
                           ,CellPhone = request.CellPhone
                           ,ContactTitle = request.ContactTitle
                           ,ContactName = request.ContactName
                           ,Email = request.Email
                           ,Address = request.Address
                           ,AreaId = request.AreaId
                           ,ActivityFieldId = request.ActivityFieldId
                           ,CreatedDate = DateTime.Now
                        };

                        await _context.Customers.AddAsync(customer);
                        await _context.SaveChangesAsync(cancellationToken);

                       // List<CustomerTrashTypes> NewCustomerTrashTypes = new List<CustomerTrashTypes>();
                        //  var TrashTypesTobeUpdate = _context.CustomerTrashTypes.Include(p => p.CustomerId).Where(p => p.CustomerId == customer.CustomerId);

                        foreach (var item in request.TrashTypes)
                        {
                            _context.CustomerTrashTypes.Add(new CustomerTrashTypes() { CustomerId = customer.CustomerId, TrashTypeId = item.TrashTypeId });
                        }
                        await _context.SaveChangesAsync(cancellationToken);

                        transaction.Commit();

                        Result.IsSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        Result.IsSuccess = false;
                        Result.Message = ex.Message;
                    }
                }

                Result.Unit = Unit.Value;
                return Result; 

            }

      
        }
    }
}
