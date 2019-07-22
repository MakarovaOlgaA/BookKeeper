namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using UserDataAPI.Enums;
    using UserDataAPI.Models;

    public static class CalculatorFactory
    {
        public static IPaymentCalculator GetBaseRateCalculator(UserResultVM user, UserResult initialUserResult, int rateTypeId)
        {
            IPaymentCalculator calculator = null;

            switch ((RateType)rateTypeId)
            {
                case RateType.PerHour:
                {
                    calculator = new HourlyBaseRateCalculator();
                    break;
                }
                case RateType.Fixed:
                {
                    calculator = new FixedBaseRateCalculator();
                    break;
                }
            }

            calculator.Configure(user, initialUserResult);

            return calculator;
        }

        public static IPaymentCalculator GetRuleCalculator(UserResultVM user, UserResult initialUserResult, long ruleTypeId)
        {
            IPaymentCalculator calculator = null;

            switch ((RuleType)ruleTypeId)
            {
                case RuleType.Annual:
                {
                    calculator = new AnnualRuleCalculator();
                    break;
                }
                case RuleType.Month:
                {
                    calculator = new MonthlyRuleCalculator();
                    break;
                }
                case RuleType.Weekend:
                {
                    calculator = new WeekendRuleCalculator();
                    break;
                }
            }

            calculator.Configure(user, initialUserResult);

            return calculator;
        }

        public static IOvertimeCalculator GetOvertimeCalculator(UserResultVM user, UserResult initialUserResult, int rateTypeId)
        {
            IOvertimeCalculator calculator = null;

            switch ((RateType)rateTypeId)
            {
                case RateType.PerHour:
                {
                    calculator = new HourlyOvertimeCalculator();
                    break;
                }
                case RateType.Fixed:
                {
                    calculator = new FixedOvertimeCalculator();
                    break;
                }
            }

            calculator.Configure(user, initialUserResult);

            return calculator;
        }
    }
}
