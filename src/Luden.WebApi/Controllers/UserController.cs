using Luden.Application.Interfaces;
using Luden.Application.Models.Requests;
using Luden.Application.Models.Responses;
using Luden.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Luden.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserRes>> Create(CreateUserReq user)
        {
            try
            {
                var result = await _userService.CreateUser(user);
                return Ok(result);
            }
            catch (UserAlreadyExistsException ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);

            }
        }

        [HttpPost]
        public async Task<ActionResult<ValidateUserRes>> Validate(ValidateUserReq req)
        {
            try
            {
                var result = await _userService.ValidateUser(req);
                return Ok(result);

            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);

            }
        }

        [HttpGet]
        public async Task<ActionResult<GetAllActiveUsersRes>> GetAll([FromQuery] string username)
        {
            try
            {
                var result = await _userService.GetAllActiveUsers(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
