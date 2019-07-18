namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UserDataAPI.Models;

    public class HourlyBaseRateCalculator : IPaymentCalculator
    {
        protected IEnumerable<TimeSheetVM> timeSheets;

        public void Configure(UserResultVM user, UserResult initialUserResult)
        {
            this.timeSheets = user.TimeSheets;
        }

        public decimal Calculate(decimal rate, DateTime startDate, DateTime endDate)
        {
            var relevantTimeSheets = timeSheets.Where(ts => ts.Date >= startDate && ts.Date < endDate);

            return relevantTimeSheets.Sum(ts => ts.Hours * rate);
        }
    }
}
