namespace BookKeeper.PaymentCalculations
{
    using System;

    public class FixedBaseRateCalculator : IBaseRateCalculator
    {
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
            var actualWorkingDays = DateHelper.GetWorkingDays(startDate, endDate);

            return rate / workingDaysTotal * actualWorkingDays;
        }


        internal class PeriodVM
        {
            public DateTime From { get; set; }
            public DateTime To { get; set; }

        }
    }
}
