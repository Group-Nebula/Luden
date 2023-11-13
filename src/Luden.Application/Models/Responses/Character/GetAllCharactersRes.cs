using Luden.Application.Models.DTOs;

namespace Luden.Application.Models.Responses.Character
{
    public class GetAllCharactersRes
    {
        public IEnumerable<CharacterDTO> Data { get; set; }
    }
}
