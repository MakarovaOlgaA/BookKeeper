namespace BookKeeper
{
    using BookKeeper.Models;
    using System;
    using System.Collections.Generic;

    public interface IUserDataProcessor
    {
        IEnumerable<UserResultVM> GetUserResults(IEnumerable<long> userIds, DateTime startDate, DateTime endDate);
    }
}
