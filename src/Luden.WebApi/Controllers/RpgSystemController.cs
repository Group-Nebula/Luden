using Luden.Application.Interfaces;
using Luden.Application.Models.Requests.RpgSystem;
using Luden.Application.Models.Responses;
using Luden.Application.Models.Responses.RpgSystem;
using Microsoft.AspNetCore.Mvc;

namespace Luden.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RpgSystemController : ControllerBase
    {
        private readonly IRpgSystemService _rpgSystemService;

        public RpgSystemController(IRpgSystemService rpgSystemService)
        {
            _rpgSystemService = rpgSystemService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateRpgSystemReq request)
        {
            try
            {
                await _rpgSystemService.Create(request);
                return Ok();
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

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateRpgSystemReq request)
        {
            try
            {
                await _rpgSystemService.Update(request);
                return Ok();
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


        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] Guid rpgSystemId)
        {
            try
            {
                await _rpgSystemService.Delete(rpgSystemId);
                return Ok();
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
        public async Task<ActionResult<GetRpgSystemByIdRes>> GetById([FromQuery] Guid rpgSystemId)
        {
            try
            {
                var result = await _rpgSystemService.GetById(rpgSystemId);
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
        public async Task<ActionResult<IEnumerable<NameIdRes>>> GetAllNameId([FromQuery] string? rpgSystemName)
        {
            try
            {
                var result = await _rpgSystemService.GetAllNameId(rpgSystemName);
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
        public async Task<ActionResult<IEnumerable<GetAllRpgSystemRes>>> GetAll([FromQuery] string? rpgSystemName)
        {
            try
            {
                var result = await _rpgSystemService.GetAll(rpgSystemName);
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
