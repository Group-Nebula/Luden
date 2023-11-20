using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public class RpgPlayerSpecifications
    {
        public static BaseSpecification<RpgPlayer> GetByRpgIdSpec(Guid rpgId)
        {
            return new BaseSpecification<RpgPlayer>(x => x.RpgId.Equals(rpgId));
        }
    }
}
