namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UserDataAPI.Models;

    public class UserRuleHandler: PaymentHandlerBase
    {
        public override decimal Calculate(UserResultVM user, UserResult initialUserResult, DateTime startDate, DateTime endDate)
        {
            var baseRate = 0M;

            var userRuleIds = initialUserResult.UserRules.Where(ur => ur.UserId == user.Id).Select(ur => ur.RuleId);
            var rules = initialUserResult.Rules.Where(r => userRuleIds.Contains(r.Id));

            foreach (var rule in rules)
            {
                var dateFrom = rule.StartDate > startDate ? rule.StartDate : startDate;
                var dateTo = rule.EndDate.HasValue && rule.EndDate < endDate ? rule.EndDate.Value : endDate;

                var calculator = CalculatorFactory.GetRuleCalculator(user, initialUserResult, rule.RuleTypeId);
                baseRate += calculator.Calculate(rule.Bonus, dateFrom, dateTo);
            }

            return baseRate + Proceed(user, initialUserResult, startDate, endDate);
        }
    }
}
