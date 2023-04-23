using Moq;
using TransactionManagement.BLL.Services.Implementations;
using TransactionManagement.DAL.Entities;
using TransactionManagement.DAL.Repositories.Interfaces;

namespace TransactionManagement.UnitTests.Tests
{
    public class TransactionServiceTests_v1
    {
        private readonly TransactionService _transactionService;

        public TransactionServiceTests_v1()
        {
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<TransactionEntity>
                {
                    new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
                });
            _transactionService = new TransactionService(transactionRepositoryMock.Object);
        }

        [Fact]
        public async Task GetTotalAsync_WhenDateHasTransactions_ShouldReturnNonZero()
        {
            var actualTotal = await _transactionService.GetTotalForDateAsync(new DateTime(2023, 04, 11));
            var expectedTotal = 10m;

            Assert.Equal(expectedTotal, actualTotal, 2);
        }

        [Fact]
        public async Task GetTotalAsync_WhenDateHasNoTransactions_ShouldReturnZero()
        {
            var actualTotal = await _transactionService.GetTotalForDateAsync(new DateTime(2023, 04, 09));
            var expectedTotal = 0m;

            Assert.Equal(expectedTotal, actualTotal, 2);
        }
    }
}