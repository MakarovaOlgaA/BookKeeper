namespace BookKeeper
{
    using System;
    using System.Collections.Generic;
    using BookKeeper.Models;
    using UserDataAPI;

    public class UserDataProcessor : IUserDataProcessor
    {
        private readonly IUserDataFetcher fetcher;

        public UserDataProcessor(IUserDataFetcher fetcher)
        {
            this.fetcher = fetcher;
        }

        public IEnumerable<UserResultVM> GetUserResults(IEnumerable<long> userIds, DateTime startDate, DateTime endDate)
        {
            var result = new List<UserResultVM>();

            var filteredData = fetcher.FilterUserData(userIds, startDate, endDate);

            return result;
        }
    }
}
