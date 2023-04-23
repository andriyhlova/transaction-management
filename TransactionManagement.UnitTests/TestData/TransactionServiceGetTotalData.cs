using System.Collections;

namespace TransactionManagement.UnitTests.TestData
{
    public class TransactionServiceGetTotalData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 11, 10 };
            yield return new object[] { 10, 2 };
            yield return new object[] { 8, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
