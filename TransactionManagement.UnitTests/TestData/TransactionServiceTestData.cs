namespace TransactionManagement.UnitTests.TestData
{
    public static class TransactionServiceTestData
    {
        public static IEnumerable<object[]> GetTotalData
        {
            get
            {
                yield return new object[] { 11, 10 };
                yield return new object[] { 10, 2 };
                yield return new object[] { 8, 0 };
            }
        }
    }
}
