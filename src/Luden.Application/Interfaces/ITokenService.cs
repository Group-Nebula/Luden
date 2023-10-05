using Luden.Domain.Entities;

namespace Luden.Application.Interfaces
{
    public interface ITokenService
    {
        string Generate(User user);
    }
}
