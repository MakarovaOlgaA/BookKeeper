namespace UserDataAPI
{
    using System;
    using System.Collections.Generic;
    using UserDataAPI.Models;

    public class UserDataFetcher: IUserDataFetcher
    {
        public UserResult FilterUserData(IEnumerable<long> userIds, DateTime startDate, DateTime endDate)
        {
            return new UserResult();
        }
    }
}
