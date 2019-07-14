namespace BookKeeper.Mappers
{
    using BookKeeper.Models;
    using UserDataAPI.Models;
    using System.Linq;

    public class UserResultMapper: IUserResultMapper
    {
        protected VacationInfoMapper vacationMapper;

        public UserResultMapper()
        {
            vacationMapper = new VacationInfoMapper();
        }

        public UserResultVM GetUser(long userId, UserResult userResult)
        {
            var user = userResult.Users.Where(u => u.Id == userId).First();
            var result = new UserResultVM() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };

            result.VacationInfo = vacationMapper.GetVacationInfo(userId, userResult);

            result.TimeSheets = userResult.UserTimeSheets.Where(ts => ts.UserId == userId)
                .Select(ts => new TimeSheetVM { Date = ts.Date, Hours = ts.Hours });

            result.Positions = userResult.UserPositions.Where(up => up.UserId == userId)
                .Join(userResult.UserPositionHours, up => up.PositionId, uph => uph.UserPositionId, (up, uph) =>
                new UserPositionVM { PositionId = up.PositionId, StartDate = up.StartDate, EndDate = up.EndDate, Hours = uph.Hours }).ToList();

            return result;
        }
    }
}
