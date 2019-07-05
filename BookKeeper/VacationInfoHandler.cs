namespace BookKeeper
{
    using System.Collections.Generic;
    using BookKeeper.Models;
    using UserDataAPI.Models;
    using System.Linq;
    using System;
    using UserDataAPI.Enums;

    public class VacationInfoHandler : BaseUserResultHandler
    {
        public override void Handle(UserResult initialUserResult, DateTime startDate, DateTime endDate, ref IEnumerable<UserResultVM> userResults)
        {
            var userVacationLimits = initialUserResult.UserDaysOff.GroupBy(udo => udo.UserId).ToDictionary(g => g.Key, g => g.ToList());
            var userTimesOff = initialUserResult.TimesOff.GroupBy(udo => udo.UserId).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var user in userResults)
            {
                var sickLeave = new DaysOffVM();
                var vacation = new DaysOffVM();

                var limitGroups = userVacationLimits[user.Id].GroupBy(udo => udo.TimeOffTypeId).Select(g => new TimeOffWithCounterVM { TimeOffType = (TimeOffType)g.First().TimeOffTypeId, Count = (short) g.Sum(udo => udo.Total) }).ToList();
                var usedTimeOffGroups = userTimesOff[user.Id].GroupBy(udo => udo.TimeOffTypeId).Select(g => new TimeOffWithCounterVM  { TimeOffType = (TimeOffType) g.First().TimeOffTypeId, Count = (short) g.Count() }).ToList();

                user.VacationInfo = BuildVacationInfo(limitGroups, usedTimeOffGroups);
            }

            Proceed(initialUserResult, startDate, endDate, ref userResults);
        }

        protected internal class TimeOffWithCounterVM {

            public TimeOffType TimeOffType { get; set; }

            public short Count { get; set; }
        }

        protected internal VacationInfoVM BuildVacationInfo(IEnumerable<TimeOffWithCounterVM> limits, IEnumerable<TimeOffWithCounterVM> usedTimesOff)
        {
            var sickLeave = new DaysOffVM()
            {
                PaidDaysTotal = GetDaysOff(limits, TimeOffType.PaidSick),
                UnpaidDaysTotal = GetDaysOff(limits, TimeOffType.UnpaidSick),
                PaidDaysUsed = GetDaysOff(usedTimesOff, TimeOffType.PaidSick),
                UnpaidDaysUsed = GetDaysOff(usedTimesOff, TimeOffType.UnpaidSick)
            };

            var vacation = new DaysOffVM()
            {
                PaidDaysTotal = GetDaysOff(limits, TimeOffType.PaidVacation),
                UnpaidDaysTotal = GetDaysOff(limits, TimeOffType.UnpaidVacation),
                PaidDaysUsed = GetDaysOff(usedTimesOff, TimeOffType.PaidVacation),
                UnpaidDaysUsed = GetDaysOff(usedTimesOff, TimeOffType.UnpaidVacation)
            };

            return new VacationInfoVM() { SickLeave = sickLeave, Vacation = vacation };
        }

        protected internal short GetDaysOff(IEnumerable<TimeOffWithCounterVM> timesOffWithCounter, TimeOffType timeOffType)
        {
            return timesOffWithCounter.Where(l => l.TimeOffType == timeOffType).Select(l => l.Count).FirstOrDefault();
        }
    }
}