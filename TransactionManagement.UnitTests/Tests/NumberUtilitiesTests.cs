using TransactionManagement.BLL.Utilities;

namespace TransactionManagement.UnitTests.Tests
{
    public class NumberUtilitiesTests
    {
        [Fact]
        public void IsPrime_WhenNumberIsPrime_ShouldReturnTrue()
        {
            var actualIsPrime = NumberUtilities.IsPrime(17);
            var expectedIsPrime = true;

            Assert.Equal(actualIsPrime, expectedIsPrime);
        }

        [Fact]
        public void IsPrime_WhenNumberIsNotPrime_ShouldReturnFalse()
        {
            var actualIsPrime = NumberUtilities.IsPrime(8);
            var expectedIsPrime = false;

            Assert.Equal(actualIsPrime, expectedIsPrime);
        }

        [Theory]
        [InlineData(17, true)]
        [InlineData(8, false)]
        [InlineData(1, false)]
        public void IsPrime_ForDifferentNumbers_ShouldReturnCorrectResult(int number, bool expected)
        {
            var actualIsPrime = NumberUtilities.IsPrime(number);
            Assert.Equal(actualIsPrime, expected);
        }
    }
}