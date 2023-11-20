using Luden.Application.Models.DTOs;
using Luden.Application.Models.Requests.Character;
using Luden.Application.Models.Responses;
using Luden.Application.Models.Responses.Character;

namespace Luden.Application.Interfaces
{
    public interface ICharacterService
    {
        Task CreateCharacter(CreateCharacterReq request);
        Task DeleteCharacter(Guid characterId);
        Task<GetAllCharactersRes> GetAllActiveCharacters(string? characterName);
        Task<GetAllCharactersRes> GetAllActiveCharactersByUserId(Guid userId);
        Task<IEnumerable<NameIdRes>> GetAllCharactersNameId(string? characterName);
        Task<CharacterDTO> GetCharacterById(Guid characterId);
        Task UpdateCharacter(UpdateCharacterReq request);
    }
}
