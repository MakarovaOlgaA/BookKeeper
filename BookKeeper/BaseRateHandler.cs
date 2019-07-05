namespace BookKeeper
{
    using System;
    using System.Collections.Generic;
    using BookKeeper.Models;
    using UserDataAPI.Models;

    public class BaseRateHandler : IUserResultHandler
    {
        public void Handle(UserResult initialUserResult, DateTime startDate, DateTime endDate, ref IEnumerable<UserResultVM> userResults)
        {
            throw new NotImplementedException();
        }

        public void SetNext(IUserResultHandler handler)
        {
            throw new NotImplementedException();
        }

        public IBaseRateCalculator GetRateCalculator(int userId, UserResult initialUserResult)
        {
            throw new NotImplementedException();
        }
    }
}
