using Luden.Application.Models.DTOs;
using Luden.Domain.Entities;

namespace Luden.Application.Interfaces
{
    public interface ICharacterSkillService
    {
        Task AddRange(IEnumerable<CharacterSkill> characterSkills);
        Task UpdateRange(IEnumerable<CharacterSkillDTO> characterSkills);
    }
}
