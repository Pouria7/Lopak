using Lopak.Domain.Entities.UserR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Lopak.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User> GetByIdAsync(int Id);
        Task ValidateAsync(TokenValidatedContext context);
    }
}
