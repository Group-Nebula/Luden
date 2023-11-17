using Luden.Application.Models.Requests.Rpg;
using Luden.Application.Models.Responses.Rpg;

namespace Luden.Application.Interfaces
{
    public interface IRpgService
    {
        Task Create(CreateRpgReq request);
        Task Update(UpdateRpgReq request);
        Task Delete(Guid rpgId);
        Task<GetAllRpgsRes> GetAllActive(string rpgName);
        Task<GetAllRpgsRes> GetAllActiveByUserId(Guid userId);
    }
}
