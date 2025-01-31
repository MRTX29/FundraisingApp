using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundraisingAppProcessor.Data;
using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Repositories;
using FundraisingAppProcessor.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace FundraisingAppProcessor.Tests.Repositories
{
    public class MoneyBoxRepositoryTests
    {
        private IMoneyBoxRepository _moneyBoxRepository;
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

            _moneyBoxRepository = new MoneyBoxRepository(ctx);
            ctx.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _connection?.Close();
        }

        [Test]
        public async Task AddMoneyBoxAsync_ShouldAddMoneyBox()
        {
            var moneyBox = new MoneyBox { DateReturned = DateTime.Now, ApprovedByAdmin = false };
            var result = await _moneyBoxRepository.AddMoneyBoxAsync(moneyBox);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetMoneyBoxByIdAsync_ShouldReturnMoneyBox()
        {
            var moneyBox = new MoneyBox { DateReturned = DateTime.Now, ApprovedByAdmin = false };
            var addedBox = await _moneyBoxRepository.AddMoneyBoxAsync(moneyBox);

            var result = await _moneyBoxRepository.GetMoneyBoxByIdAsync(addedBox.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(addedBox.Id));
        }

        [Test]
        public async Task GetAllMoneyBoxesAsync_ShouldReturnAllMoneyBoxes()
        {
            var moneyBox1 = new MoneyBox { DateReturned = DateTime.Now, ApprovedByAdmin = false };
            var moneyBox2 = new MoneyBox { DateReturned = DateTime.Now, ApprovedByAdmin = false };
            await _moneyBoxRepository.AddMoneyBoxAsync(moneyBox1);
            await _moneyBoxRepository.AddMoneyBoxAsync(moneyBox2);

            var result = await _moneyBoxRepository.GetAllMoneyBoxesAsync();

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task UpdateMoneyBoxAsync_ShouldUpdateMoneyBox()
        {
            var moneyBox = new MoneyBox { DateReturned = DateTime.Now, ApprovedByAdmin = false };
            var addedBox = await _moneyBoxRepository.AddMoneyBoxAsync(moneyBox);

            addedBox.ApprovedByAdmin = true;
            await _moneyBoxRepository.UpdateMoneyBoxAsync(addedBox);

            var result = await _moneyBoxRepository.GetMoneyBoxByIdAsync(addedBox.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ApprovedByAdmin, Is.True);
        }

        [Test]
        public async Task DeleteMoneyBoxAsync_ShouldDeleteMoneyBox()
        {
            var moneyBox = new MoneyBox { DateReturned = DateTime.Now, ApprovedByAdmin = false };
            var addedBox = await _moneyBoxRepository.AddMoneyBoxAsync(moneyBox);

            await _moneyBoxRepository.DeleteMoneyBoxAsync(addedBox.Id);

            var result = await _moneyBoxRepository.GetMoneyBoxByIdAsync(addedBox.Id);

            Assert.That(result, Is.Null);
        }
    }
}
