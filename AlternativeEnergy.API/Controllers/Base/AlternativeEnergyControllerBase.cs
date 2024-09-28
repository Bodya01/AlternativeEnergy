using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.API.Controllers.Base
{
    [Authorize]
    public class AlternativeEnergyControllerBase : ControllerBase
    {
    }
}
