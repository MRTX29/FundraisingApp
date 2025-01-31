using FundraisingAppProcessor.Data;
using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Repositories;
using FundraisingAppProcessor.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FundraisingAppProcessor.Tests.Integration
{
    public class FundraisingWorkflowTests
    {
        private IMoneyBoxService _moneyBoxService;
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
            _moneyBoxService = new MoneyBoxService(_moneyBoxRepository);
            ctx.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _connection?.Close();
        }

        [Test]
        public async Task Fundraising_Box_Workflow_Test()
        {
            // User submits a box
            var submittedBox = await _moneyBoxService.CreateMoneyBoxAsync(DateTime.Now);
            Assert.That(submittedBox, Is.Not.Null);
            Assert.That(submittedBox.ApprovedByAdmin, Is.False);

            // Admin approves the box
            var approvedBox = await _moneyBoxService.ApproveMoneyBoxAsync(submittedBox.Id);
            Assert.That(approvedBox, Is.Not.Null);
            Assert.That(approvedBox.ApprovedByAdmin, Is.True);

            // Counter counts the denominations
            var denominations = new Denominations
            {
                Count10gr = 10,
                Count10 = 5,
                OtherCurrencies = "100 pesos"
            };
            var countedBox = await _moneyBoxService.UpdateDenominationsAsync(approvedBox.Id, denominations);
            Assert.That(countedBox, Is.Not.Null);
            Assert.That(countedBox.Denominations.Count10gr, Is.EqualTo(denominations.Count10gr));
            Assert.That(countedBox.Denominations.Count10, Is.EqualTo(denominations.Count10));
            Assert.That(countedBox.Denominations.OtherCurrencies, Is.EqualTo(denominations.OtherCurrencies));
        }
    }
}
