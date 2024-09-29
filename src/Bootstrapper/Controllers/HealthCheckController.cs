using Microsoft.AspNetCore.Mvc;

namespace Bootstrapper.Controllers
{
    [ApiController]
    [Route("api/health-check")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Pong!");
        }
    }
}
