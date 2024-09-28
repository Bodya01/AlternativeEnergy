using AlternativeEnergy.API.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.API.Controllers
{
    [ApiController]
    [Route("api/health-check")]
    public class HealthCheckController : AlternativeEnergyControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Pong!");
        }
    }
}
