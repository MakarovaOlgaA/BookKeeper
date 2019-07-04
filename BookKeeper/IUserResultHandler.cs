namespace BookKeeper
{
    using System.Collections.Generic;
    using UserDataAPI.Models;
    using BookKeeper.Models;
    using System;

    public interface IUserResultHandler
    {
        void SetNext(IUserResultHandler handler);

        void Handle(UserResult initialUserResult, DateTime startDate, DateTime endDate, ref IEnumerable<UserResultVM> userResults);
    }
}
