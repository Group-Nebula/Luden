using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Application.Models.Requests.Character;
using Luden.Application.Models.Responses;
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

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCharacterReq request)
        {
            try
            {
                await _characterService.CreateCharacter(request);
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
        public async Task<ActionResult> Update([FromBody] UpdateCharacterReq request)
        {
            try
            {
                await _characterService.UpdateCharacter(request);
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
        public async Task<ActionResult> Delete([FromQuery] Guid characterId)
        {
            try
            {
                await _characterService.DeleteCharacter(characterId);
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
        public async Task<ActionResult<CharacterDTO>> GetById([FromQuery] Guid characterId)
        {
            try
            {
                var result = await _characterService.GetCharacterById(characterId);
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
        public async Task<ActionResult<IEnumerable<NameIdRes>>> GetAllNameId([FromQuery] string? characterName)
        {
            try
            {
                var result = await _characterService.GetAllCharactersNameId(characterName);
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
        public async Task<ActionResult<GetAllCharactersRes>> GetAllActive([FromQuery] string? characterName)
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