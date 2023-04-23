namespace TransactionManagement.BLL.Utilities
{
    public static class NumberUtilities
    {
        public static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (var i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
