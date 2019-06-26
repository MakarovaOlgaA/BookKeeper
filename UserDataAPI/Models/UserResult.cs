namespace UserDataAPI.Models
{
    using System.Collections.Generic;

    public class UserResult
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Position> Positions { get; set; }
        public IEnumerable<OvertimeRatio> OvertimeRatios { get; set; }
        public IEnumerable<UserTimeSheet> UserTimeSheets { get; set; }
        public IEnumerable<UserTimeOff> TimesOff { get; set; }
        public IEnumerable<UserPosition> UserPositions { get; set; }
        public IEnumerable<UserPositionHours> UserPositionHours { get; set; }
        public IEnumerable<DayOff> DaysOff { get; set; }
        public IEnumerable<UserDayOff> UserDaysOff { get; set; }
        public IEnumerable<Rule> Rules { get; set; }
        public IEnumerable<PositionRule> PositionRules { get; set; }
        public IEnumerable<UserRule> UserRules { get; set; }
    }
}
