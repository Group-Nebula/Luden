using Luden.Application.Models.Responses.Character;

namespace Luden.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<GetAllActiveCharactersRes> GetAllActiveCharacters(string charactername);
    }
}
