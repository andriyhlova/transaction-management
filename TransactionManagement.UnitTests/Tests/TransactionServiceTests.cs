using Moq;
using TransactionManagement.BLL.Services.Implementations;
using TransactionManagement.DAL.Entities;
using TransactionManagement.DAL.Repositories.Interfaces;
using TransactionManagement.UnitTests.TestData;

namespace TransactionManagement.UnitTests.Tests
{
    public class TransactionServiceTests
    {
        [Fact]
        public async Task GetTotalAsync_WhenDateHasTransactions_ShouldReturnNonZero()
        {
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<TransactionEntity>
                {
                    new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
                });

            var transactionService = new TransactionService(transactionRepositoryMock.Object);
            var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, 11));
            var expectedTotal = 10m;

            Assert.Equal(expectedTotal, actualTotal, 3);
        }

        [Fact]
        public async Task GetTotalAsync_WhenDateHasNoTransactions_ShouldReturnZero()
        {
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<TransactionEntity>
                {
                    new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
                });

            var transactionService = new TransactionService(transactionRepositoryMock.Object);
            var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, 09));
            var expectedTotal = 0m;

            Assert.Equal(expectedTotal, actualTotal, 2);
        }

        [Theory]
        [InlineData(11, 10)]
        [InlineData(10, 2)]
        [InlineData(9, 0)]
        public async Task GetTotalAsync_WhenDateIsCorrect_ShouldReturnCorrectTotal(int day, decimal expectedTotal)
        {
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<TransactionEntity>
                {
                    new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
                });

            var transactionService = new TransactionService(transactionRepositoryMock.Object);
            var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, day));

            Assert.Equal(expectedTotal, actualTotal, 2);
        }

        [Theory]
        [ClassData(typeof(TransactionServiceGetTotalData))]
        public async Task GetTotalAsync_WhenDateIsCorrect_ShouldReturnCorrectTotal1(int day, decimal expectedTotal)
        {
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<TransactionEntity>
                {
                    new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
                });

            var transactionService = new TransactionService(transactionRepositoryMock.Object);
            var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, day));

            Assert.Equal(expectedTotal, actualTotal, 2);
        }

        [Theory]
        [MemberData(nameof(TransactionServiceTestData.GetTotalData), MemberType = typeof(TransactionServiceTestData))]
        public async Task GetTotalAsync_WhenDateIsCorrect_ShouldReturnCorrectTotal2(int day, decimal expectedTotal)
        {
            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<TransactionEntity>
                {
                    new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
                });

            var transactionService = new TransactionService(transactionRepositoryMock.Object);
            var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, day));

            Assert.Equal(expectedTotal, actualTotal, 2);
        }
    }
}