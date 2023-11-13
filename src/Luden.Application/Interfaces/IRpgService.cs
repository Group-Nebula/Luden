using Luden.Application.Models.Responses.Rpg;

namespace Luden.Application.Interfaces
{
    public interface IRpgService
    {
        Task<GetAllRpgsRes> GetAllActive(string rpgName);
        Task<GetAllRpgsRes> GetAllActiveByUserId(Guid userId);
    }
}
