using System;

namespace BookKeeper
{
    public static class DateHelper
    {
        public static int GetWorkingDays(DateTime startDate, DateTime endDate)
        {
            var totalDays = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday)
                    totalDays++;
            }

            return totalDays;
        }
    }
}
