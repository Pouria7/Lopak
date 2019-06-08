
using System.Threading.Tasks;
using Lopak.Application.Actions.Cities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Lopak.Web.Controllers
{

    public class TestController : BaseController
    {
        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Commercial")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateCityCommand command)
        {
            await Mediator.Send(command);


            return NoContent();
        }
    }
}