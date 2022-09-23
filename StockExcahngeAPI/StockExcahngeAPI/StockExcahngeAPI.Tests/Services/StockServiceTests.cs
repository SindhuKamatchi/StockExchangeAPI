using FluentAssertions;
using LondonStockExchangeApi.Client;
using LondonStockExchangeApi.Interface;
using LondonStockExchangeApi.Tests.Fixtures;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LondonStockExchangeApi.Tests.Client
{
    public class StockServiceTests
    {
        private readonly Mock<ILogger<StockService>> _mockLogger;
        private readonly IStockService _underTest;

        public StockServiceTests()
        {
            _mockLogger = new Mock<ILogger<StockService>>();
            _underTest = new StockService(_mockLogger.Object);
        }
        [Fact]
        public async Task WhenSaveStockDetailsIsCalled_With_Valid_StockDetails()
        {
            //Arrange

            //Act
            var actualResponse = await _underTest.SaveStockDetails(StockDetailsFixture.stockDetailsValidRequest);

            // Assert
            actualResponse.Should().BeTrue();
        }
        [Fact]
        public async Task WhenStockServiceIsCalled_With_InValid_StockDetails()
        {
            //Arrange

            //Act
            var actualResponse = await _underTest.SaveStockDetails(StockDetailsFixture.stockDetailsInValidRequest);

            // Assert
            actualResponse.Should().BeFalse();
        }
    }

}
