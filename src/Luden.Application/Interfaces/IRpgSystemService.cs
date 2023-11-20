using Luden.Application.Models.DTOs;
using Luden.Application.Models.Requests.RpgSystem;
using Luden.Application.Models.Responses;
using Luden.Application.Models.Responses.RpgSystem;

namespace Luden.Application.Interfaces
{
    public interface IRpgSystemService
    {
        Task Delete(Guid rpgSystemId);
        Task Update(UpdateRpgSystemReq request);
        Task Create(CreateRpgSystemReq request);
        Task<RpgSystemDTO> GetById(Guid rpgSystemId);
        Task<IEnumerable<NameIdRes>> GetAllNameId(string? rpgSystemName);
        Task<IEnumerable<GetAllRpgSystemRes>> GetAll(string? rpgSystemName);
    }
}
