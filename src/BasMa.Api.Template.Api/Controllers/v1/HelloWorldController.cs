using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
