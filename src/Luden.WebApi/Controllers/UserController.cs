using Luden.Application.Interfaces;
using Luden.Application.Models.Requests.User;
using Luden.Application.Models.Responses.User;
using Luden.Domain.Exceptions.User;
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
            catch (UserAlreadyExistsException)
            {
                return Conflict(new ProblemDetails
                {
                    Status = StatusCodes.Status409Conflict,
                    Title = "User already exists",
                    Detail = "This username or email alredy exists",
                    Instance = HttpContext.Request.Path
                });
            }
            catch (Exception)
            {
                return new ObjectResult(new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Ops! Something went wrong",
                    Detail = "Try again later",
                    Instance = HttpContext.Request.Path
                })
                {
                    ContentTypes = { "application/problem+json" },
                    StatusCode = StatusCodes.Status500InternalServerError
                };
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
            catch (UserNotFoundException)
            {
                return new ObjectResult(new ProblemDetails
                {
                    Status = StatusCodes.Status403Forbidden,
                    Title = "User not found",
                    Detail = "This email or password is incorrect",
                    Instance = HttpContext.Request.Path
                })
                {
                    ContentTypes = { "application/problem+json" },
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
            catch (Exception)
            {
                return new ObjectResult(new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Ops! Something went wrong",
                    Detail = "Try again later",
                    Instance = HttpContext.Request.Path
                })
                {
                    ContentTypes = { "application/problem+json" },
                    StatusCode = StatusCodes.Status500InternalServerError
                };
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
            catch (Exception)
            {
                return new ObjectResult(new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Ops! Something went wrong",
                    Detail = "Try again later",
                    Instance = HttpContext.Request.Path
                });
            }
        }
    }
}
