namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UserDataAPI.Models;

    public class OvertimeHandler: PaymentHandlerBase
    {
        public override decimal Calculate(UserResultVM user, UserResult initialUserResult, DateTime startDate, DateTime endDate)
        {
            var overtimeBonus = 0M;

            var holidays = initialUserResult.DaysOff.Select(doff => doff.Date);

            foreach (var userPosition in user.Positions)
            {
                var positionDateFrom = userPosition.StartDate > startDate ? userPosition.StartDate : startDate;
                var positionDateTo = userPosition.EndDate.HasValue && userPosition.EndDate < endDate ? userPosition.EndDate.Value : endDate;

                var rateInfo = initialUserResult.Positions.Where(p => p.Id == userPosition.PositionId).Select(p => new { p.RateTypeId, p.Rate }).First();
                var overtimeRatio = initialUserResult.OvertimeRatios.Where(or => or.RateTypeId == rateInfo.RateTypeId).Select(or=>or.Ratio).First();

                var relevantTimeSheets = user.TimeSheets.Where(ts => ts.Date >= positionDateFrom && ts.Date <= positionDateTo);

                var calculator = CalculatorFactory.GetOvertimeCalculator(user, initialUserResult, rateInfo.RateTypeId);
                overtimeBonus += calculator.Calculate(rateInfo.Rate, overtimeRatio, userPosition.Hours, positionDateFrom, positionDateTo);
            }

            return overtimeBonus + Proceed(user, initialUserResult, startDate, endDate);
        }
    }
}
