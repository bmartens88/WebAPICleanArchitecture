using BasMa.Api.Template.Core.Application.Features.Hello.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BasMa.Api.Template.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HelloWorldController : BaseApiController
    {
        /// <summary>
        /// API Call which returns a string resource "Hello World!"
        /// </summary>
        /// <response code="200">Unless an exception would occur, always returns a 200 OK</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hello World!");

        /// <summary>
        /// API Call to get a greeting from the server :)
        /// </summary>
        /// <param name="query">Query object</param>
        [HttpPost]
        public async Task<ActionResult<string>> GetGreeting(GetGreetingQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
