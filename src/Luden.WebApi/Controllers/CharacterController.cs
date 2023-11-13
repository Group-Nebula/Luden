using Luden.Application.Interfaces;
using Luden.Application.Models.Responses.Character;
using Microsoft.AspNetCore.Mvc;

namespace Luden.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllCharactersRes>> GetAllActive([FromQuery] string characterName)
        {
            try
            {
                var result = await _characterService.GetAllActiveCharacters(characterName);
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
        public async Task<ActionResult<GetAllCharactersRes>> GetAllByUserId([FromQuery] Guid userId)
        {
            try
            {
                var result = await _characterService.GetAllActiveCharactersByUserId(userId);
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
