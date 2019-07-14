namespace BookKeeper.Mappers
{
    using System.Collections.Generic;
    using BookKeeper.Models;
    using UserDataAPI.Models;
    using System.Linq;
    using UserDataAPI.Enums;

    public class VacationInfoMapper
    {
        public VacationInfoVM GetVacationInfo(long userId, UserResult userResult)
        {
            var userVacationLimits = userResult.UserDaysOff.Where(udo => udo.UserId == userId).ToList();
            var usedTimesOff = userResult.TimesOff.Where(uto => uto.UserId == userId).ToList();

            var limitGroups = userVacationLimits.GroupBy(udo => udo.TimeOffTypeId)
                .Select(g => new TimeOffWithCounterVM { TimeOffType = (TimeOffType)g.First().TimeOffTypeId, Count = (short)g.Sum(udo => udo.Total) }).ToList();

            var usedTimeOffGroups = usedTimesOff.GroupBy(udo => udo.TimeOffTypeId)
                .Select(g => new TimeOffWithCounterVM { TimeOffType = (TimeOffType)g.First().TimeOffTypeId, Count = (short)g.Count() }).ToList();

            return GetVacationInfo(limitGroups, usedTimeOffGroups);
        }

        protected internal VacationInfoVM GetVacationInfo(IEnumerable<TimeOffWithCounterVM> limits, IEnumerable<TimeOffWithCounterVM> usedTimesOff)
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

        protected internal class TimeOffWithCounterVM
        {
            public TimeOffType TimeOffType { get; set; }

            public short Count { get; set; }
        }
    }
}