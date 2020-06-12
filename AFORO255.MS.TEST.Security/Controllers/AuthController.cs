using AFORO255.MS.TEST.Security.Dto;
using AFORO255.MS.TEST.Security.Service;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceAccess _serviceAccess;

        public AuthController(IServiceAccess serviceAccess)
        {
            _serviceAccess = serviceAccess;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceAccess.GetAll());
        }


        [HttpPost]
        public IActionResult Post([FromBody] AuthRequestDto request)
        {

            if (!_serviceAccess.Validate(request.username, request.password))
            {
                return Unauthorized();
            }

            //Response.Headers.Add("access-control-expose-headers", "Authorization");
            //Response.Headers.Add("Authorization", JwtToken.Create(_jwtOption));

            return Ok();
        }

    }
}
