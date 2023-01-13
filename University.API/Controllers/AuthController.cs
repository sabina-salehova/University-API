using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Univeristy.AuthenticationService.Contracts;
using Univeristy.AuthenticationService.Models;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult GetToken([FromBody] TokenRequestModel model)
        {
            var token = _authService.GetToken(model);
            return Ok(token);
        }
    }
}
