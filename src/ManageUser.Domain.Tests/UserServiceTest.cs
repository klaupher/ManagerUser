using FluentAssertions;
using ManageUser.Domain.Interfaces.Repositories;
using ManageUser.Domain.Interfaces.Services;
using ManageUser.Domain.Services;
using ManageUser.Infra.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ManageUser.Domain.Tests
{
    public class UserServiceTest
    {
        public UserService _userService;

        public Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAsync_WhenIsValid_ShallRequestAddNewUser()
        {
            //Arrange
            ManageUser.Domain.Entities.User user = new
                (name: "teste",
                email: "teste@avanade.com",
                password: "abc123");

            _userRepositoryMock.Setup(b => b.CreateAsync(user))
                .Returns(It.IsAny<Domain.Entities.User>);

            //Act
            var actual = await _userService.CreateAsync(user);

            //Assert
            actual.Should().NotBeNull();

            _userRepositoryMock.Verify(b => b.CreateAsync(It.IsAny<ManageUser.Domain.Entities.User>()),
            times: Times.Once);
        }
    }
}