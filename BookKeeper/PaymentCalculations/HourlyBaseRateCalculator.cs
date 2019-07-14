namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HourlyBaseRateCalculator : IBaseRateCalculator
    {
        protected IEnumerable<TimeSheetVM> timeSheets;

        public HourlyBaseRateCalculator(IEnumerable<TimeSheetVM> timeSheets)
        {
            this.timeSheets = timeSheets;
        }

        public decimal Calculate(decimal rate, DateTime startDate, DateTime endDate)
        {
            var relevantTimeSheets = timeSheets.Where(ts => ts.Date >= startDate && ts.Date < endDate);

            return relevantTimeSheets.Sum(ts => ts.Hours * rate);
        }
    }
}
