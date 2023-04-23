using TransactionManagement.BLL.Services.Implementations;
using TransactionManagement.UnitTests.ClassFixtures;

namespace TransactionManagement.UnitTests.Tests
{
    public class TransactionServiceTests_v2 : IClassFixture<TransactionServiceClassFixture>
    {
        readonly TransactionServiceClassFixture _fixture;

        public TransactionServiceTests_v2(TransactionServiceClassFixture fixture)
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