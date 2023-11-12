using Luden.Application.Models.Responses.Character;

namespace Luden.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<GetAllCharactersRes> GetAllActiveCharacters(string characterName);
        Task<GetAllCharactersRes> GetAllActiveCharactersByUserId(Guid userId);
    }
}
