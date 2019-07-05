namespace BookKeeper
{
    using System;

    public interface IBaseRateCalculator
    {
        decimal Calculate(decimal rate, DateTime StartDate, DateTime EndDate);
    }
}
