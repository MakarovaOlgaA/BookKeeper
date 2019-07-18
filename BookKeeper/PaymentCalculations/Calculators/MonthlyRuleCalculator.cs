namespace BookKeeper.PaymentCalculations
{
    using System;
    using BookKeeper.Models;
    using UserDataAPI.Models;

    public class MonthlyRuleCalculator : IPaymentCalculator
    {
        public decimal Calculate(decimal rate, DateTime startDate, DateTime endDate)
        {
            var months = DateHelper.GetMonths(startDate, endDate);
            return months * rate;
        }

        public void Configure(UserResultVM user, UserResult initialUserResult)
        {
        }
    }
}
