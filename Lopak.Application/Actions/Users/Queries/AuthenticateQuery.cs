using Lopak.Application.Actions.Users.Queries;
using Lopak.Application.Exceptions;
using Lopak.Application.Infrastructure;
using Lopak.Application.Interfaces;
using Lopak.Domain.Entities.Common;
using Lopak.Domain.Entities.UserR;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lopak.Application.Actions.Users.Queries
{
    public class AuthenticateQuery : IRequest<UserCallbackViewModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RemoteIpAddress { get; set; }

        public class Handler : IRequestHandler<AuthenticateQuery, UserCallbackViewModel>
        {
            private readonly ILopakDbContext _context;
            private readonly IOptionsSnapshot<BearerTokensOptions> _configuration;

            public Handler(ILopakDbContext context, IOptionsSnapshot<BearerTokensOptions> configuration)
            {
                _context = context;
                _configuration = configuration;
            }

            public async Task<UserCallbackViewModel> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.Username == request.Username);

                var UserCallback = new UserCallbackViewModel();

                if (user == null)
                    throw new LoginException(AutExMode.UsernameNotAvailable);

               if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    throw new LoginException(AutExMode.WrongPassword);

               if (user.IsActive == false)
                    throw new LoginException(AutExMode.DisabledAccount);


                UserCallback.DisplayName = user.DisplayName;

                //Add Roles 
                user.UserRoles =  _context.UserRole.Where(x => x.UserId == user.Id).Include(u => u.Role).ToList();
                    
                foreach (var item in user.UserRoles)
                {
                    UserCallback.Roles.Add(item.RoleId);
                }



                var now = DateTimeOffset.UtcNow;
                var accessTokenExpiresDateTime = now.AddMinutes(_configuration.Value.AccessTokenExpirationMinutes);
                var refreshTokenExpiresDateTime = now.AddMinutes(_configuration.Value.RefreshTokenExpirationMinutes);
                var accessToken = CreateAccessToken(user, accessTokenExpiresDateTime.UtcDateTime);
                var refreshToken = Guid.NewGuid().ToString().Replace("-", "");

                UserCallback.AccessToken = accessToken;

                //await AddUserTokenAsync(user, refreshToken, accessToken, refreshTokenExpiresDateTime, accessTokenExpiresDateTime).ConfigureAwait(false);
                //await _uow.SaveChangesAsync().ConfigureAwait(false);

                //await _context.UserToken.AddAsync(new UserToken() {
                //    UserId = user.Id,
                //    AccessTokenExpiresDateTime = accessTokenExpiresDateTime,
                //    RemoteIpAddress = request.RemoteIpAddress
                // });

                //await _context.SaveChangesAsync(cancellationToken);

                return UserCallback;
            }

            private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
            {
                if (password == null) throw new ArgumentNullException("password");
                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
                if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
                if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

                using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != storedHash[i]) return false;
                    }
                }
                return true;
            }

            private string CreateAccessToken(User user, DateTime expires)
            {
                string g = "g";

                var claims = new List<Claim>
            {
                // Unique Id for all Jwt tokes
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Issuer
                //new Claim(JwtRegisteredClaimNames.Iss, _configuration.Value.Issuer),
                // Issued at
                //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToUnixEpochDate().ToString(), ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                //new Claim("DisplayName", user.DisplayName),
                // to invalidate the cookie
                //new Claim(ClaimTypes.SerialNumber, user.SerialNumber),
                // custom data
                //new Claim(ClaimTypes.UserData, user.Id.ToString())
            };

               
                var roles = user.UserRoles;
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Value.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: _configuration.Value.Issuer,
                    audience: _configuration.Value.Audience,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: expires,
                    signingCredentials: creds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }



        }

    }
}


