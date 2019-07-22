namespace BookKeeper.PaymentCalculations
{
    using System;
    using System.Collections.Generic;
    using BookKeeper.Models;
    using UserDataAPI.Models;
    using System.Linq;

    public class WeekendRuleCalculator: IPaymentCalculator
    {
        protected IEnumerable<TimeSheetVM> timesheets;
        protected IEnumerable<DateTime> holidays;

        public decimal Calculate(decimal rate, DateTime startDate, DateTime endDate)
        {
            var relevantTimeSheets = timesheets.Where(ts => ts.Date >= startDate && ts.Date <= endDate);

            var numberOfWeekends = relevantTimeSheets.Count(ts => ts.Date.DayOfWeek == DayOfWeek.Saturday || ts.Date.DayOfWeek == DayOfWeek.Sunday
            || holidays.Contains(ts.Date));

            return numberOfWeekends * rate;
        }

        public void Configure(UserResultVM user, UserResult initialUserResult)
        {
            this.timesheets = user.TimeSheets;
            this.holidays = initialUserResult.DaysOff.Select(doff => doff.Date);
        }
    }
}
