using Luden.Application.Models.DTOs;

namespace Luden.Application.Models.Responses.Character
{
    public class GetAllActiveCharactersRes
    {
        public IEnumerable<CharacterDTO> Data { get; set; }
    }
}
