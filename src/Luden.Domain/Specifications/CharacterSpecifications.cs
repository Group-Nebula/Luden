using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public class CharacterSpecifications
    {
        public static BaseSpecification<Character> GetAllActiveCharactersSpec(string? characterName)
        {
            return new BaseSpecification<Character>(x => (string.IsNullOrEmpty(characterName) || x.Name.Contains(characterName.Trim())) && !x.IsDeleted);
        }

        public static BaseSpecification<Character> GetById(Guid CharacterId)
        {
            return new BaseSpecification<Character>(x => x.Id.Equals(CharacterId));
        }

        public static BaseSpecification<Character> GetAllActiveCharactersByUserIdSpec(Guid userId)
        {
            return new BaseSpecification<Character>(x => x.UserId.Equals(userId) && !x.IsDeleted);
        }

    }
}
