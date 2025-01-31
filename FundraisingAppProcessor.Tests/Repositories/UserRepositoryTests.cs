using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundraisingAppProcessor.Data;
using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FundraisingAppProcessor.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private IUserRepository _repository;
        private SqliteConnection _connection;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<FundraisingContext>()
                .UseSqlite(_connection)
                .Options;

            var ctx = new FundraisingContext(options);

            _repository = new UserRepository(ctx);
            ctx.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _connection?.Close();
        }

        [Test]
        public async Task AddUserAsync_ShouldAddUser()
        {
            var user = new User { Username = "testuser", Password = "password", Role = UserRole.Counter };
            var result = await _repository.AddUserAsync(user);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldReturnUser()
        {
            var user = new User { Username = "testuser", Password = "password", Role = UserRole.Counter };
            var addedUser = await _repository.AddUserAsync(user);

            var result = await _repository.GetUserByIdAsync(addedUser.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(addedUser.Id));
        }

        [Test]
        public async Task GetUserByUsernameAsync_ShouldReturnUser()
        {
            var user = new User { Username = "testuser", Password = "password", Role = UserRole.Counter };
            await _repository.AddUserAsync(user);

            var result = await _repository.GetUserByUsernameAsync("testuser");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Username, Is.EqualTo("testuser"));
        }

        [Test]
        public async Task GetAllUsersAsync_ShouldReturnAllUsers()
        {
            var user1 = new User { Username = "testuser1", Password = "password1", Role = UserRole.Counter };
            var user2 = new User { Username = "testuser2", Password = "password2", Role = UserRole.Counter };
            await _repository.AddUserAsync(user1);
            await _repository.AddUserAsync(user2);

            var result = await _repository.GetAllUsersAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task UpdateUserAsync_ShouldUpdateUser()
        {
            var user = new User { Username = "testuser", Password = "password", Role = UserRole.Counter };
            var addedUser = await _repository.AddUserAsync(user);

            addedUser.Password = "newpassword";
            await _repository.UpdateUserAsync(addedUser);

            var result = await _repository.GetUserByIdAsync(addedUser.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Password, Is.EqualTo("newpassword"));
        }

        [Test]
        public async Task DeleteUserAsync_ShouldDeleteUser()
        {
            var user = new User { Username = "testuser", Password = "password", Role = UserRole.Counter };
            var addedUser = await _repository.AddUserAsync(user);

            await _repository.DeleteUserAsync(addedUser.Id);

            var result = await _repository.GetUserByIdAsync(addedUser.Id);

            Assert.That(result, Is.Null);
        }
    }
}
