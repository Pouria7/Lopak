using Lopak.Application.Interfaces;
using Lopak.Domain.Entities.UserR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Lopak.Application.Services
{

    public class AuthService : IAuthService
    {
        private readonly ILopakDbContext _context;
        private readonly IUserDataBox _userData;
        public AuthService(ILopakDbContext context, IUserDataBox userData)
        {
            _context = context;
            _userData = userData;
        }
        public async Task<User> GetByIdAsync(int Id)
        {
           return  await _context.Users.FindAsync(Id);
        }

        public async Task ValidateAsync(TokenValidatedContext context)
        {
            var userPrincipal = context.Principal;

            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return;
            }
            // claimsIdentity.
            var userId = int.Parse(userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var user = await GetByIdAsync(userId);
            if (user == null)
            {
                context.Fail("This is not our issued token. It has no user-id.");
                return;
            }
            
                await  _userData.Init(user);             
            
           

        }
    }
}
