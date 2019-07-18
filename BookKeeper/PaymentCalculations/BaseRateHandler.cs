namespace BookKeeper.PaymentCalculations
{
    using System;
    using BookKeeper.Models;
    using UserDataAPI.Enums;
    using UserDataAPI.Models;
    using System.Linq;

    public class BaseRateHandler : PaymentHandlerBase
    {
        public override decimal Calculate(UserResultVM user, UserResult initialUserResult, DateTime startDate, DateTime endDate)
        {
            var baseRate = 0M;

            foreach (var userPosition in user.Positions)
            {
                var dateFrom = userPosition.StartDate > startDate ? userPosition.StartDate : startDate;
                var dateTo = userPosition.EndDate.HasValue && userPosition.EndDate < endDate ? userPosition.EndDate.Value : endDate;

                var position = initialUserResult.Positions.Where(p => p.Id == userPosition.PositionId).First();
                var calculator = GetRateCalculator(user, initialUserResult, position.RateTypeId);
                baseRate += calculator.Calculate(position.Rate, dateFrom, dateTo);
            }

            return baseRate + Proceed(user, initialUserResult, startDate, endDate);
        }

        internal IPaymentCalculator GetRateCalculator(UserResultVM user, UserResult initialUserResult, int rateTypeId)
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
    }
}
