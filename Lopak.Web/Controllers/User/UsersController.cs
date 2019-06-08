using System.Threading.Tasks;
using AutoMapper;
using Lopak.Application.Actions.Users.Commands;
using Lopak.Application.Actions.Users.Queries;
using Lopak.Application.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Lopak.Web.Controllers.User
{
    public class UsersController : BaseController
    {
        [HttpPost]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserCallbackViewModel>> Login([FromBody]UserDto command)
        {
           // var Authenticate = Mapper.Map<UserDto, AuthenticateQuery>(command);
            var RemoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var UserCallback = await Mediator.Send(new AuthenticateQuery() {
                Username = command.Username,
                Password = command.Password,
                RemoteIpAddress = RemoteIpAddress
            });
            return UserCallback;
        }
    
       [HttpPost]
       [ProducesDefaultResponseType]
        public async Task<ActionResult<CommandActionResult>> CreateCommercial([FromBody]CreateCommercialUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}