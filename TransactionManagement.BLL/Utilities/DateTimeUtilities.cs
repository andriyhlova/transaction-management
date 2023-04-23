namespace TransactionManagement.BLL.Utilities
{
    public static class DateTimeUtilities
    {
        public static int GetBusinessDays(DateTime startDate, DateTime endDate)
        {
            int days = (int)(endDate - startDate).TotalDays + 1;
            int fullWeekCount = days / 7;
            int remainingDays = days % 7;

            int businessDays = fullWeekCount * 5;

            for (int i = 0; i < remainingDays; i++)
            {
                DayOfWeek currentDay = (startDate.AddDays(i)).DayOfWeek;
                if (currentDay != DayOfWeek.Saturday && currentDay != DayOfWeek.Sunday)
                {
                    businessDays++;
                }
            }

            return businessDays;
        }
    }
}
