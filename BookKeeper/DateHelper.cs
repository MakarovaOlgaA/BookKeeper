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

        public static int GetMonths(DateTime startDate, DateTime endDate)
        {
            var totalMonths = 0;
            for (var date = startDate; date <= endDate; date = date.AddMonths(1))
            {
                totalMonths++;
            }

            return totalMonths;
        }

        public static int GetWeeks (DateTime startDate, DateTime endDate)
        {
            var totalWeeks = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(7))
            {
                totalWeeks++;
            }

            return totalWeeks;
        }

        public static int GetYears(DateTime startDate, DateTime endDate)
        {
            var totalYears = 0;
            for (var date = startDate; date <= endDate; date = date.AddYears(1))
            {
                totalYears++;
            }

            return totalYears;
        }
    }
}
