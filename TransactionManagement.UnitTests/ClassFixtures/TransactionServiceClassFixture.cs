using Moq;
using TransactionManagement.DAL.Entities;
using TransactionManagement.DAL.Repositories.Interfaces;

namespace TransactionManagement.UnitTests.ClassFixtures
{
    public class TransactionServiceClassFixture
    {
        public Mock<ITransactionRepository> TransactionRepositoryMock { get; }

        public TransactionServiceClassFixture()
        {
            TransactionRepositoryMock = new Mock<ITransactionRepository>();
            TransactionRepositoryMock.Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(new List<TransactionEntity>
                {
                    new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
                });
        }
    }
}
