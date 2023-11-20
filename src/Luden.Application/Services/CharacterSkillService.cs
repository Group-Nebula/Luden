using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;
using Luden.Domain.Specifications;

namespace Luden.Application.Services
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacterSkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddRange(IEnumerable<CharacterSkill> characterSkills)
        {
            if (!characterSkills.Any())
            {
                throw new ArgumentException("No skills to add");
            }

            return _unitOfWork.Repository<CharacterSkill>().AddRangeAsync(characterSkills);
        }

        public async Task UpdateRange(IEnumerable<CharacterSkillDTO> characterSkillsDTO)
        {
            if (!characterSkillsDTO.Any())
            {
                throw new ArgumentException("No skills to update");
            }

            var characterSkillsSpec = CharacterSkillSpecifications.GetAllActiveSkillByCharacterIdSpec(characterSkillsDTO.First().CharacterId);

            var characterSkills = await _unitOfWork.Repository<CharacterSkill>().ListAsync(characterSkillsSpec);

            var characterSkillUpdated = new List<CharacterSkill>();

            foreach (var characterSkill in characterSkills)
            {
                var charSkill = characterSkills.FirstOrDefault(cs => cs.SkillId == characterSkill.SkillId);

                if (charSkill == null)
                    continue;

                charSkill.Value = characterSkill.Value;
                characterSkillUpdated.Add(charSkill);
            }

            _unitOfWork.Repository<CharacterSkill>().UpdateRange(characterSkillUpdated);
        }
    }
}
