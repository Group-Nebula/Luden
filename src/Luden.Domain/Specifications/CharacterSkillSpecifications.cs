using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public class CharacterSkillSpecifications
    {
        public static BaseSpecification<CharacterSkill> GetAllActiveSkillByCharacterIdSpec(Guid characterId)
        {
            return new BaseSpecification<CharacterSkill>(x => x.CharacterId.Equals(characterId) && !x.IsDeleted);
        }
    }
}
