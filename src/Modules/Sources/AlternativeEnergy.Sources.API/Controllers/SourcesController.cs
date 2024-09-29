using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.Sources.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/sources")]
    public class SourcesController : ControllerBase
    {

        [HttpGet("get/{userId:guid}")]
        public IActionResult Get(Guid userId)
        {
            return Ok();
        }
    }
}
