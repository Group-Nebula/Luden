using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public class RpgSpecifications
    {
        public static BaseSpecification<Rpg> GetAllActiveRpgsSpec(string? rpgName)
        {
            return new BaseSpecification<Rpg>(x => (x.Name.Contains(rpgName) || string.IsNullOrEmpty(rpgName)) && !x.IsDeleted);
        }

        public static BaseSpecification<Rpg> GetAllActiveByUserIdRpgsSpec(Guid userId)
        {
            return new BaseSpecification<Rpg>(x => (x.RpgPlayers.Any(x => x.PlayerId.Equals(userId)) || x.MasterId.Equals(userId)) && !x.IsDeleted);
        }
    }
}
