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
        public static BaseSpecification<Character> GetAllActiveCharactersByUserIdSpec(Guid userId)
        {
            return new BaseSpecification<Character>(x => x.Id.Equals(userId) && !x.IsDeleted);
        }
    }
}
