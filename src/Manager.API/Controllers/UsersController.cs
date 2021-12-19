using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserViewModel user)
        {
            try
            {
                var userCreated = await _userService.Create(_mapper.Map<UserDto>(user));

                return CreatedAtRoute("", new { UserId = userCreated.Id }, new ResultViewModel
                {
                    Message = "User created successfully",
                    Success = true,
                    Data = _mapper.Map<UserViewModel>(userCreated)
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(DomainErrorResponse(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationErrorResponse());
            }
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUserAsync(Guid userId, [FromBody] UpdateUserViewModel user)
        {
            try
            {
                if (!userId.Equals(user.Id))
                {
                    return BadRequest(new ResultViewModel()
                    {
                        Message = "Id's entered are different",
                        Success = false,
                        Data = null
                    });
                }

                await _userService.Update(_mapper.Map<UserDto>(user));

                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(DomainErrorResponse(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationErrorResponse());
            }
        }

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> RemoveUserAsync(Guid userId)
        {
            try
            {
                await _userService.Remove(userId);

                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(DomainErrorResponse(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationErrorResponse());
            }
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid userId)
        {
            try
            {
                return Ok(_mapper.Map<UserViewModel>(await _userService.FindById(userId)));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationErrorResponse());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<UserViewModel>>(await _userService.GetAll()));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationErrorResponse());
            }
        }

        [HttpGet("Email/{email:required}")]
        public async Task<IActionResult> SearchUsersByEmailAsync(string email)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<UserViewModel>>(await _userService.SearchByEmail(email)));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationErrorResponse());
            }
        }


        [HttpGet("Name/{name:alpha:required}")]
        public async Task<IActionResult> SearchUsersByNameAsync(string name)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<UserViewModel>>(await _userService.SearchByName(name)));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationErrorResponse());
            }
        }
    }
}
