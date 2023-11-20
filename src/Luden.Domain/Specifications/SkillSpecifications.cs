using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public class SkillSpecifications
    {
        public static BaseSpecification<Skill> GetAllBySystemId(Guid rpgSystemId)
        {
            return new BaseSpecification<Skill>(x => x.RpgSystemId.Equals(rpgSystemId));
        }
    }
}
