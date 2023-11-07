using Luden.Application.Models.Responses.Rpg;

namespace Luden.Application.Interfaces
{
    public interface IRpgService
    {
        Task<GetAllActiveRpgsRes> GetAllActiveRpgs(string rpgname);
    }
}
