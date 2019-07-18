namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using System;
    using UserDataAPI.Models;

    public interface IPaymentCalculator
    {
        void Configure(UserResultVM user, UserResult initialUserResult);

        decimal Calculate(decimal rate, DateTime startDate, DateTime endDate);
    }
}
