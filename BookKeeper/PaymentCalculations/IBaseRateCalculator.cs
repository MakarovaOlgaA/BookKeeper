namespace BookKeeper.PaymentCalculations
{
    using System;

    public interface IBaseRateCalculator
    {
        decimal Calculate(decimal rate, DateTime startDate, DateTime endDate);
    }
}
