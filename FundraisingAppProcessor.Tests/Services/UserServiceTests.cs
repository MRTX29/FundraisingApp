using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Repositories;
using FundraisingAppProcessor.Services;
using Moq;

namespace FundraisingAppProcessor.Tests.Services
{
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock = new();
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Test]
        public async Task CreateUserAsync_Test()
        {
            // Arrange
            var user = new User
            {
                Username = "testuser",
                Password = "password",
                Role = UserRole.Admin
            };
            _userRepositoryMock.Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            _userRepositoryMock.Setup(x => x.AddUserAsync(It.IsAny<User>())).ReturnsAsync(user);
            // Act
            var result = await _userService.CreateUserAsync(user.Username, user.Password, user.Role);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(user.Username, Is.EqualTo(result.Username));
            Assert.That(user.Password, Is.EqualTo(result.Password));
            Assert.That(user.Role, Is.EqualTo(result.Role));
        }

        [Test]
        public void CreateUserAsync_UserExistsTest()
        {
            // Arrange
            var user = new User
            {
                Username = "testuser",
                Password = "password",
                Role = UserRole.Admin
            };
            _userRepositoryMock.Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>())).ReturnsAsync(user);
            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => _userService.CreateUserAsync(user.Username, user.Password, user.Role));
        }

        [Test]
        public async Task ValidateUserAsync_ValidUserTest()
        {
            // Arrange
            var user = new User
            {
                Username = "testuser",
                Password = "password",
                Role = UserRole.Admin
            };
            _userRepositoryMock.Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>())).ReturnsAsync(user);
            // Act
            var result = await _userService.ValidateUserAsync(user.Username, user.Password);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(user.Username, Is.EqualTo(result.Username));
            Assert.That(user.Password, Is.EqualTo(result.Password));
            Assert.That(user.Role, Is.EqualTo(result.Role));
        }

        [Test]
        public async Task ValidateUserAsync_UserDoesntExistTest()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            // Act
            var result = await _userService.ValidateUserAsync(string.Empty, string.Empty);
            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ValidateUserAsync_DifferentPasswordTest()
        {
            // Arrange
            var user = new User
            {
                Username = "testuser",
                Password = "password",
                Role = UserRole.Admin
            };
            _userRepositoryMock.Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>())).ReturnsAsync(user);
            // Act
            var result = await _userService.ValidateUserAsync(user.Username, "anotherpassword");
            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
