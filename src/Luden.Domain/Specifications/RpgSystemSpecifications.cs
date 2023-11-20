using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public class RpgSystemSpecifications
    {
        public static BaseSpecification<RpgSystem> GetAllActiveRpgSystemsSpec(string? rpgSystemName)
        {
            return new BaseSpecification<RpgSystem>(x => (x.Name.Contains(rpgSystemName) || string.IsNullOrEmpty(rpgSystemName)) && !x.IsDeleted);
        }
    }
}
