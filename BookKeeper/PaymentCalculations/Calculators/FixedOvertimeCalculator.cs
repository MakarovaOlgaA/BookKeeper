namespace BookKeeper.PaymentCalculations
{
    using System;
    using System.Collections.Generic;
    using BookKeeper.Models;
    using UserDataAPI.Models;

    public class FixedOvertimeCalculator : IOvertimeCalculator
    {
        public decimal Calculate(decimal rate, decimal overtimeRatio, int dailyNorm, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void Configure(UserResultVM user, UserResult initialUserResult)
        {
            throw new NotImplementedException();
        }
    }
}
