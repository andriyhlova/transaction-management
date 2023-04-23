using TransactionManagement.BLL.Utilities;

namespace TransactionManagement.UnitTests.Tests
{
    public class DateTimeUtilitiesTests
    {
        [Fact]
        public void GetBusinessDays_WhenStartDateIsWeekend_ShouldReturnCorrectValue()
        {
            var actualBusinessDays = DateTimeUtilities.GetBusinessDays(new DateTime(2023, 04, 8), new DateTime(2023, 04, 14));
            var expectedBusinessDays = 5;

            Assert.Equal(actualBusinessDays, expectedBusinessDays);
        }

        [Fact]
        public void GetBusinessDays_WhenEndDateIsWeekend_ShouldReturnCorrectValue()
        {
            var actualBusinessDays = DateTimeUtilities.GetBusinessDays(new DateTime(2023, 04, 4), new DateTime(2023, 04, 08));
            var expectedBusinessDays = 4;

            Assert.Equal(actualBusinessDays, expectedBusinessDays);
        }
    }
}