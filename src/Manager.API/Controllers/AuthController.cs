using System;
using Manager.API.Security;
using Manager.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Manager.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            try
            {
                var tokenLogin = _configuration["Jwt:Login"];
                var tokenPassword = _configuration["Jwt:Password"];

                if (login.Email != tokenLogin || login.Password != tokenPassword)
                    return Unauthorized(UnauthorizedErrorMessage());

                return Ok(new ResultViewModel()
                {
                    Message = "user successfully logged in!",
                    Success = true,
                    Data = new
                    {
                        Token = _tokenGenerator.GenerateToken(),
                        ExpiresAt = double.Parse(_configuration["Jwt:Expires"])
                    }
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationErrorResponse());
            }
        }
    }
}
