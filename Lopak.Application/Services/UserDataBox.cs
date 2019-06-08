using Lopak.Application.Interfaces;
using Lopak.Domain.Entities.Common;
using Lopak.Domain.Entities.UserR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lopak.Application.Services
{
    public sealed class UserDataBox: IUserDataBox
    {
        private readonly ILopakDbContext _context;
        public UserDataBox(ILopakDbContext context)
        {
            _context = context;
        }

        public int? UserId { get; private set; }
        public string Username { get;private set; }
        public string DisplayName { get; private set; }
        public ICollection<UserRole> Roles { get; private set; }
        public City City { get; private set; }
        public Area Area { get; private set; }

        public Task Init(User user)
        {
            if (UserId != null)
            {
                var roles = _context.UserRole.Where(x => x.UserId == user.Id).ToList();
                
                Username = user.Username;
                DisplayName = user.DisplayName;
                // Roles = roles;
                Roles = roles;

                if (Roles.Where(x => x.RoleId == 5).Count() > 0)
                {
                    //User is Customer
                    var Customer = _context.Customers.Where(x => x.UserId == user.Id).FirstOrDefault();
                    Area = Customer.Area;
                    City = Customer.Area.City;
                }
            }
            return Task.CompletedTask;
        }
        public void Init(int userId)
        {
           // var tokenValidatorService = _context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
        }

        public void Clear()
        {
            UserId = null;
        }
    }

   
}
