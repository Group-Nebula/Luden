using Luden.Application.Models.Requests;
using Luden.Application.Models.Responses;

namespace Luden.Application.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserRes> CreateUser(CreateUserReq req);

        Task<ValidateUserRes> ValidateUser(ValidateUserReq req);

        Task<GetAllActiveUsersRes> GetAllActiveUsers(string? username);
    }
}