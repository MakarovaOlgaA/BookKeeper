namespace UserDataAPI
{
    using System;
    using System.Collections.Generic;
    using UserDataAPI.Models;

    public interface IUserDataFetcher
    {
        UserResult FilterUserData(IEnumerable<long> userIds, DateTime startDate, DateTime endDate);
    }
}
