using Luden.Application.Core.Services;
using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Application.Models.Requests.User;
using Luden.Application.Models.Responses.User;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;
using Luden.Domain.Exceptions.User;
using Luden.Domain.Specifications;

namespace Luden.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _loggerService;
        private readonly ITokenService _tokenService;

        public UserService(IUnitOfWork unitOfWork, ILoggerService loggerService, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _loggerService = loggerService;
            _tokenService = tokenService;
        }

        public async Task<CreateUserRes> CreateUser(CreateUserReq req)
        {
            var UsersSpec = UserSpecifications.GetUserByEmailOrUsernameSpec(req.Email, req.UserName);

            if (await _unitOfWork.Repository<User>().CountAsync(UsersSpec) > 0)
            {
                _loggerService.LogInfo("User already exists");

                throw new UserAlreadyExistsException();
            };

            var user = await _unitOfWork.Repository<User>().AddAsync(new User
            {
                Username = req.UserName,
                Email = req.Email,
                Password = req.Password,
            });

            await _unitOfWork.SaveChangesAsync();

            _loggerService.LogInfo($"user: {user.Id} created");

            return new CreateUserRes() { Data = _tokenService.Generate(user) };
        }

        public async Task<ValidateUserRes> ValidateUser(ValidateUserReq req)
        {
            var validateUserSpec = UserSpecifications.GetUserByEmailAndPasswordSpec(req.Email, req.Password);

            var user = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(validateUserSpec);

            if (user == null)
            {
                _loggerService.LogInfo("User not found");

                throw new UserNotFoundException();
            }

            return new ValidateUserRes()
            {
                Id = user.Id,
                Name = user.Username,
                Token = _tokenService.Generate(user)
            };
        }

        public async Task<GetAllActiveUsersRes> GetAllActiveUsers(string? username)
        {
            var activeUsersSpec = UserSpecifications.GetAllActiveUsersSpec(username);

            var users = await _unitOfWork.Repository<User>().ListAsync(activeUsersSpec);

            return new GetAllActiveUsersRes()
            {
                Data = users.Select(x => new UserDTO(x)).ToList()
            };
        }
    }
}