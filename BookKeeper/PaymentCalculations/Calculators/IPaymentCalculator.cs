namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using System;
    using UserDataAPI.Models;

    public interface IPaymentCalculator: IConfigurable
    {
        decimal Calculate(decimal rate, DateTime startDate, DateTime endDate);
    }
}
