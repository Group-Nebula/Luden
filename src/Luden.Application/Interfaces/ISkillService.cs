using Luden.Application.Models.DTOs;

namespace Luden.Application.Interfaces
{
    public interface ISkillService
    {
        Task AddRange(IEnumerable<SkillsDTO> skillsDTO);
    }
}
