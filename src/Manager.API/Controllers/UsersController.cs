using System;
using System.Threading.Tasks;
using Manager.API.ViewModels;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Manager.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserViewModel user)
        {
            try
            {

            }
            catch (DomainException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong trying to process your request.");
            }
        }
    }
}
