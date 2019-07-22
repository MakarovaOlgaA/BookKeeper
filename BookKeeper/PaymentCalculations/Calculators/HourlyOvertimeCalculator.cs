namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using System;
    using UserDataAPI.Models;

    public class HourlyOvertimeCalculator : IOvertimeCalculator
    {
        public decimal Calculate(decimal rate, decimal overtimeRatio, int dailyNorm, DateTime startDate, DateTime endDate)
        {
            // return rate * overtimeRatio * hours;
            return 0;
        }

        public void Configure(UserResultVM user, UserResult initialUserResult)
        {
            throw new NotImplementedException();
        }
    }
}