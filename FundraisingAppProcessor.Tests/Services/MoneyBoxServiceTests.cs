using FundraisingAppProcessor.Models;
using FundraisingAppProcessor.Repositories;
using FundraisingAppProcessor.Services;
using Moq;

namespace FundraisingAppProcessor.Tests.Services
{
    public class MoneyBoxServiceTests
    {
        private Mock<IMoneyBoxRepository> _repositoryMock = new();
        private MoneyBoxService _serviceUnderTest;

        [SetUp]
        public void Setup()
        {
            _serviceUnderTest = new(_repositoryMock.Object);
        }

        [Test]
        public async Task ApproveMoneyBoxAsync_Test()
        {
            // Arrange
            var box = new MoneyBox()
            {
                DateReturned = DateTime.Now,
                ApprovedByAdmin = true,
            };
            _repositoryMock
                .Setup(m => m.GetMoneyBoxByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => box);

            // Act
            var resultBox = await _serviceUnderTest.ApproveMoneyBoxAsync(0);

            //Assert
            Assert.That(resultBox, Is.Not.Null);
            Assert.That(resultBox.DateReturned, Is.EqualTo(box.DateReturned));
            Assert.That(resultBox.ApprovedByAdmin, Is.True);
        }

        [Test]
        public void ApproveMoneyBoxAsync_BoxNullTest()
        {
            // Arrange
            _repositoryMock
                .Setup(m => m.GetMoneyBoxByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => _serviceUnderTest.ApproveMoneyBoxAsync(0));
        }

        [Test]
        public async Task UpdateDenominationsAsync_Test()
        {
            // Arrange
            var box = new MoneyBox()
            {
                Denominations = null!
            };
            var denominations = new Denominations()
            {
                Count10gr = 10,
                Count10 = 0,
                OtherCurrencies = "100 pesos"
            };
            _repositoryMock
                .Setup(m => m.GetMoneyBoxByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => box);

            //Act
            var resultBox = await _serviceUnderTest.UpdateDenominationsAsync(0, denominations);

            // Assert
            Assert.That(resultBox.Denominations, Is.Not.Null);
            Assert.That(resultBox.Denominations.Count10gr, Is.EqualTo(denominations.Count10gr));
            Assert.That(resultBox.Denominations.Count10, Is.EqualTo(denominations.Count10));
            Assert.That(resultBox.Denominations.OtherCurrencies, Is.EqualTo(denominations.OtherCurrencies));
        }

        [Test]
        public void UpdateDenominationsAsync_BoxNullTest()
        {
            // Arrange
            _repositoryMock
                .Setup(m => m.GetMoneyBoxByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            // Act & Assert
            Assert.ThrowsAsync<Exception>(() => _serviceUnderTest.UpdateDenominationsAsync(0, new Denominations()));
        }
    }
}
