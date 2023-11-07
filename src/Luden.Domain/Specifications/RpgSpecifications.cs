using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public class RpgSpecifications
    {
        public static BaseSpecification<Rpg> GetAllActiveRpgsSpec(string rpgname)
        {
            return new BaseSpecification<Rpg>(x => x.Name.Contains(rpgname) && !x.IsDeleted);
        }
    }
}
