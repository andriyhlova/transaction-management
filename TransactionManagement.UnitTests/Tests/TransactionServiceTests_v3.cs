using TransactionManagement.BLL.Services.Implementations;
using TransactionManagement.UnitTests.ClassFixtures;

namespace TransactionManagement.UnitTests.Tests
{
    [Collection("TransactionServiceCollectionFixture")]
    public class TransactionServiceTests_v3
    {
        readonly TransactionServiceClassFixture _fixture;

        public TransactionServiceTests_v3(TransactionServiceClassFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetTotalAsync_WhenDateHasTransactions_ShouldReturnNonZero()
        {
            var transactionService = new TransactionService(_fixture.TransactionRepositoryMock.Object);
            var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, 11));
            var expectedTotal = 10m;

            Assert.Equal(expectedTotal, actualTotal, 2);
        }
    }
}