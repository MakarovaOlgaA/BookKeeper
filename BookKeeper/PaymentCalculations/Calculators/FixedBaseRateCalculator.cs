namespace BookKeeper.PaymentCalculations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BookKeeper.Models;
    using UserDataAPI.Models;

    public class FixedBaseRateCalculator : IPaymentCalculator
    {
        protected IEnumerable<DateTime> holidays;

        public void Configure(UserResultVM user, UserResult initialUserResult)
        {
            this.holidays = initialUserResult.DaysOff.Select(doff => doff.Date);
        }
        

        public decimal Calculate(decimal rate, DateTime startDate, DateTime endDate)
        {
            if (startDate.Year == endDate.Year && startDate.Month == endDate.Month)
            {
                return CalculateMonthlyPayment(rate, startDate, endDate);
            }

            var total = 0M;

            DateTime dateFrom, dateTo;
            dateFrom = dateTo = startDate;

            do
            {
                dateTo = new DateTime(dateFrom.Year, dateFrom.Month, DateTime.DaysInMonth(dateFrom.Year, dateFrom.Month));
                total += CalculateMonthlyPayment(rate, dateFrom, dateTo);
                dateFrom = dateTo.AddDays(1);
            } while (dateTo < endDate);

            return total;
        }

        public decimal CalculateMonthlyPayment(decimal rate, DateTime startDate, DateTime endDate)
        {
            var workingDaysTotal = DateTime.DaysInMonth(startDate.Year, startDate.Month);

            var holidaysTotal = this.holidays.Where(h => h >= startDate && h <= endDate).Count();
            var actualWorkingDays = DateHelper.GetWorkingDays(startDate, endDate) - holidaysTotal;

            return rate / workingDaysTotal * actualWorkingDays;
        }

        internal class PeriodVM
        {
            public DateTime From { get; set; }
            public DateTime To { get; set; }
        }
    }
}
