using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Security.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok();
    }
}
