using Luden.Domain.Entities;
using Luden.Domain.Enums;
using Luden.Infrastructure.Data;
using Luden.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Luden.Infrastructure.Test.Repositories
{
    public class BaseRepositoryAsyncTest
    {
        private readonly LudenDbContext _LudenDbContext;
        private readonly UnitOfWork _unitOfWork;

        public BaseRepositoryAsyncTest()
        {
            var options = new DbContextOptionsBuilder<LudenDbContext>().UseInMemoryDatabase(databaseName: "LudenDb").Options;
            _LudenDbContext = new LudenDbContext(options);
            _unitOfWork = new UnitOfWork(_LudenDbContext);
        }

        [Fact]
        public async void Given_ValidData_When_AddAsync_Then_SuccessfullyInsertData()
        {
            // Arrange
            var user = new User
            {
                UserName = "Nilav",
                Email = "nilavpatel1992@gmail.com",
                Password = "Test123",
                Status = UserStatus.Active,
                CreatedAt = DateTime.UtcNow
            };

            // Act
            var result = await _unitOfWork.Repository<User>().AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            // Assert
            Assert.Equal(result, _LudenDbContext.Users.Find(result.Id));
        }
    }
}