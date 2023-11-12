using Luden.Application.Models.DTOs;

namespace Luden.Application.Models.Responses.Rpg
{
    public class GetAllRpgsRes
    {
        public IEnumerable<RpgDTO> Data { get; set; }
    }
}
