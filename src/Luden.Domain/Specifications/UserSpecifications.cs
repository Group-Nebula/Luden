using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;
using Luden.Domain.Enums;

namespace Luden.Domain.Specifications
{
    public static class UserSpecifications
    {
        public static BaseSpecification<User> GetUserByEmailAndPasswordSpec(string email, string password)
        {
            return new BaseSpecification<User>(x => x.Email == email && x.Password == password && x.IsDeleted == false);
        }

        public static BaseSpecification<User> GetAllActiveUsersSpec()
        {
            return new BaseSpecification<User>(x => x.Status == UserStatus.Active && x.IsDeleted == false);
        }
    }
}
