namespace BookKeeper
{
    using System.Collections.Generic;
    using BookKeeper.Models;
    using UserDataAPI.Models;
    using System.Linq;
    using System;

    public class VacationInfoHandler : BaseUserResultHandler
    {
        public override void Handle(UserResult initialUserResult, DateTime startDate, DateTime endDate, ref IEnumerable<UserResultVM> userResults)
        {
            var userVacations = initialUserResult.UserDaysOff.GroupBy(udo => udo.UserId);
            foreach (var user in userResults)
            {

            }
            Proceed(initialUserResult, startDate, endDate, ref userResults);
        }
    }
}