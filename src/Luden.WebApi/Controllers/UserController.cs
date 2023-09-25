using Luden.Application.Interfaces;
using Luden.Application.Models.Requests;
using Luden.Application.Models.Responses;
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
            var result = await _userService.CreateUser(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ValidateUserRes>> Validate(ValidateUserReq req)
        {
            var result = await _userService.ValidateUser(req);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<GetAllActiveUsersRes>> GetAll()
        {
            var result = await _userService.GetAllActiveUsers();
            return Ok(result);
        }
    }
}
