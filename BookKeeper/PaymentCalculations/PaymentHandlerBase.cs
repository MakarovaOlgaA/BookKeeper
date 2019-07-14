namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using UserDataAPI.Models;
    using System;

    public class PaymentHandlerBase : IPaymentHandler
    {
        protected IPaymentHandler nextHandler;

        public virtual decimal Calculate(UserResultVM user, UserResult initialUserResult, DateTime startDate, DateTime endDate)
        {
            return 0M;
        }

        public void SetNext(IPaymentHandler handler)
        {
            nextHandler = handler;
        }

        protected decimal Proceed(UserResultVM user, UserResult initialUserResult, DateTime startDate, DateTime endDate)
        {
            if (nextHandler != null)
            {
                return nextHandler.Calculate(user, initialUserResult, startDate, endDate);
            }

            else return 0M;
        }
    }
}
