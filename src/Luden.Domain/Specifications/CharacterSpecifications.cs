using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public class CharacterSpecifications
    {
        public static BaseSpecification<Character> GetAllActiveCharactersSpec(string charactername)
        {
            return new BaseSpecification<Character>(x => x.Name.Contains(charactername) && !x.IsDeleted);
        }
    }
}
