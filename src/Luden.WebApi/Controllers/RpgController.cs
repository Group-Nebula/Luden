using Luden.Application.Interfaces;
using Luden.Application.Models.Responses.Rpg;
using Microsoft.AspNetCore.Mvc;

namespace Luden.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RpgController : ControllerBase
    {
        private readonly IRpgService _rpgService;

        public RpgController(IRpgService rpgService)
        {
            _rpgService = rpgService;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllRpgsRes>> GetAll([FromQuery] string? rpgName)
        {
            try
            {
                var result = await _rpgService.GetAllActive(rpgName);
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

        [HttpGet]
        public async Task<ActionResult<GetAllRpgsRes>> GetAllByUserId([FromQuery] Guid userId)
        {
            try
            {
                var result = await _rpgService.GetAllActiveByUserId(userId);
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
