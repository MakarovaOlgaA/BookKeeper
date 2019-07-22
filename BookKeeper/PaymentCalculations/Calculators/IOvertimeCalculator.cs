namespace BookKeeper.PaymentCalculations
{
    using System;

    public interface IOvertimeCalculator: IConfigurable
    {
        decimal Calculate(decimal rate, decimal overtimeRatio, int dailyNorm, DateTime startDate, DateTime endDate);
    }
}
