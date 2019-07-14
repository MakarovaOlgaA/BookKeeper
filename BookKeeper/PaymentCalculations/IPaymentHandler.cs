namespace BookKeeper.PaymentCalculations
{
    using UserDataAPI.Models;
    using BookKeeper.Models;
    using System;

    public interface IPaymentHandler
    {
        void SetNext(IPaymentHandler handler);

        decimal Calculate(UserResultVM user, UserResult initialUserResult, DateTime startDate, DateTime endDate);
    }
}
