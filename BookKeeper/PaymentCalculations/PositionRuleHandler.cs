﻿namespace BookKeeper.PaymentCalculations
{
    using BookKeeper.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UserDataAPI.Enums;
    using UserDataAPI.Models;

    public class PositionRuleHandler: PaymentHandlerBase
    {
        public override decimal Calculate(UserResultVM user, UserResult initialUserResult, DateTime startDate, DateTime endDate)
        {
            var baseRate = 0M;

           
            foreach (var userPosition in user.Positions)
            {
                var positionDateFrom = userPosition.StartDate > startDate ? userPosition.StartDate : startDate;
                var positionDateTo = userPosition.EndDate.HasValue && userPosition.EndDate < endDate ? userPosition.EndDate.Value : endDate;

                foreach (var rule in GetRules(initialUserResult, userPosition.PositionId))
                {
                    var ruleDateFrom = rule.StartDate > positionDateFrom ? rule.StartDate : positionDateFrom;
                    var ruleDateTo = rule.EndDate.HasValue && rule.EndDate < positionDateTo ? rule.EndDate.Value : positionDateTo;

                    var calculator = GetRuleCalculator(rule.RuleTypeId);
                    baseRate += calculator.Calculate(rule.Bonus, ruleDateFrom, ruleDateTo);
                }
            }

            return baseRate + Proceed(user, initialUserResult, startDate, endDate);
        }

        protected IEnumerable<Rule> GetRules(UserResult initialUserResult, int positionId)
        {
            var positionRuleIds = initialUserResult.PositionRules.Where(pr => pr.PositionId == positionId).Select(pr=>pr.RuleId);
            return initialUserResult.Rules.Where(r => positionRuleIds.Contains(r.Id));
        }

        internal IPaymentCalculator GetRuleCalculator(long ruleTypeId)
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
            }

            return calculator;
        }
    }
}
