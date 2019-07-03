namespace BookKeeper
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using BookKeeper.Models;
    using UserDataAPI;
    using UserDataAPI.Models;

    public class UserDataProcessor : IUserDataProcessor
    {
        private readonly IUserDataFetcher fetcher;

        public UserDataProcessor(IUserDataFetcher fetcher)
        {
            this.fetcher = fetcher;
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserResultVM>()); //will move it elsewhere later
        }

        public IEnumerable<UserResultVM> GetUserResults(IEnumerable<long> userIds, DateTime startDate, DateTime endDate)
        {
            var filteredData = fetcher.FilterUserData(userIds, startDate, endDate);
            var result = Mapper.Map<IEnumerable<User>, IEnumerable<UserResultVM>>(filteredData.Users);

            return result;
        }
    }
}
