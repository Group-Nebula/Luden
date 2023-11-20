using Luden.Application.Models.DTOs;
using Luden.Application.Models.Responses;

namespace Luden.Application.Interfaces
{
    public interface ISkillService
    {
        Task AddRange(IEnumerable<SkillsDTO> skillsDTO);
        Task<IEnumerable<NameIdRes>> GetAllBySystemId(Guid rpgSystemId);
    }
}
