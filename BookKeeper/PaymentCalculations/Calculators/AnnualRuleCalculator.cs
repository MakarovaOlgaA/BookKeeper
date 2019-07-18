namespace BookKeeper.PaymentCalculations
{
    using System;
    using BookKeeper.Models;
    using UserDataAPI.Models;

    public class AnnualRuleCalculator : IPaymentCalculator
    {
        public decimal Calculate(decimal rate, DateTime startDate, DateTime endDate)
        {
            var years = DateHelper.GetYears(startDate, endDate);
            return years * rate;
        }

        public void Configure(UserResultVM user, UserResult initialUserResult)
        {
        }
    }
}
