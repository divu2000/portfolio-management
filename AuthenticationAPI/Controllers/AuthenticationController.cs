using AuthenticationAPI.Models;
using AuthenticationAPI.Repository;
using AuthenticationAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthenticationController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginCredentials login)
        {
            IActionResult response = Unauthorized();

            var user = userService.AuthenticateUser(login);
            if(user == null)
            {
                return Unauthorized(new CustomResponse(401, "Invalid Credential"));
            }
            else
            {
                var tokenString = userService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Authenticate()
        {
            return Ok(true);
        }
    }
}
