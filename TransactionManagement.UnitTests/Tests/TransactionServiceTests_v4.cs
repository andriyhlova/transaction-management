using TransactionManagement.BLL.Services.Implementations;
using TransactionManagement.UnitTests.ClassFixtures;

namespace TransactionManagement.UnitTests.Tests
{
    [Collection("TransactionServiceCollectionFixture")]
    public class TransactionServiceTests_v4
    {
        readonly TransactionServiceClassFixture _fixture;

        public TransactionServiceTests_v4(TransactionServiceClassFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetTotalAsync_WhenDateHasNoTransactions_ShouldReturnZero()
        {
            var transactionService = new TransactionService(_fixture.TransactionRepositoryMock.Object);
            var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, 09));
            var expectedTotal = 0m;

            Assert.Equal(expectedTotal, actualTotal, 2);
        }
    }
}