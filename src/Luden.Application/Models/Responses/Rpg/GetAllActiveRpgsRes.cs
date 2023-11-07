using Luden.Application.Models.DTOs;

namespace Luden.Application.Models.Responses.Rpg
{
    public class GetAllActiveRpgsRes
    {
        public IEnumerable<RpgDTO> Data { get; set; }
    }
}
