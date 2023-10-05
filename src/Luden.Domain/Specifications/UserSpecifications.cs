using Luden.Domain.Core.Specifications;
using Luden.Domain.Entities;

namespace Luden.Domain.Specifications
{
    public static class UserSpecifications
    {
        public static BaseSpecification<User> GetUserByEmailAndPasswordSpec(string email, string password)
        {
            return new BaseSpecification<User>(x => x.Email.Equals(email) && x.Password.Equals(password) && !x.IsDeleted);
        }

        public static BaseSpecification<User> GetUserByEmailOrUsernameSpec(string email, string username)
        {
            return new BaseSpecification<User>(x => x.Email == email || x.Username == username);
        }

        public static BaseSpecification<User> GetAllActiveUsersSpec(string username)
        {
            return new BaseSpecification<User>(x => x.Username.Contains(username) && !x.IsDeleted);
        }
    }
}
