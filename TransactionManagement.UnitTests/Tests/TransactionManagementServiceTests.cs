using Moq;
using TransactionManagement.BLL.Services.Implementations;
using TransactionManagement.DAL.Entities;
using TransactionManagement.DAL.Repositories.Interfaces;

namespace TransactionManagement.UnitTests.Tests
{
    public class TransactionManagementServiceTests
    {
        //[Fact]
        //public async Task GetTotalForDateAsync_WhenDateIsValid_ShouldReturnValidAmout()
        //{
        //    //Arrange

        //    Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
        //    transactionRepository.Setup(m => m.GetAllAsync()).ReturnsAsync(new List<TransactionEntity>
        //    {
        //        new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
        //            new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
        //            new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
        //    });

        //    var transactionService = new TransactionService(transactionRepository.Object);


        //    //Act

        //    var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, 11));

        //    //Assert

        //    Assert.Equal(10, actualTotal);
        //}

        [Theory]
        [InlineData(11, 10)]
        [InlineData(10, 2)]
        [InlineData(9, 0)]
        public async Task GetTotalForDateAsync_WhenDateIsValid_ShouldReturnValidAmout(int day, decimal expectedTotal)
        {
            //Arrange

            Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
            transactionRepository.Setup(m => m.GetAllAsync()).ReturnsAsync(new List<TransactionEntity>
            {
                new TransactionEntity{ Id = 1, Date= new DateTime(2023, 04, 11), Amount = 2 },
                    new TransactionEntity{ Id = 2, Date= new DateTime(2023, 04, 11), Amount = 8 },
                    new TransactionEntity{ Id = 3, Date= new DateTime(2023, 04, 10), Amount = 2 }
            });

            var transactionService = new TransactionService(transactionRepository.Object);


            //Act

            var actualTotal = await transactionService.GetTotalForDateAsync(new DateTime(2023, 04, day));

            //Assert

            Assert.Equal(expectedTotal, actualTotal);
        }
    }
}
