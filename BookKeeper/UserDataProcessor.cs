namespace BookKeeper
{
    using System;
    using System.Collections.Generic;
    using BookKeeper.Models;
    using UserDataAPI;
    using BookKeeper.Mappers;
    using BookKeeper.PaymentCalculations;

    public class UserDataProcessor : IUserDataProcessor
    {
        private readonly IUserDataFetcher fetcher;
        private IUserResultMapper mapper;

        public UserDataProcessor(IUserDataFetcher fetcher, IUserResultMapper mapper)
        {
            this.fetcher = fetcher;
            this.mapper = mapper;
        }

        public IEnumerable<UserResultVM> GetUserResults(IEnumerable<long> userIds, DateTime startDate, DateTime endDate)
        {
            var filteredData = fetcher.FilterUserData(userIds, startDate, endDate);
            var result = new List<UserResultVM>();

            var chain = new BaseRateHandler();
            chain.SetNext(new OvertimeHandler());
            chain.SetNext(new TimeOffHandler());
            chain.SetNext(new PositionRuleHandler());
            chain.SetNext(new UserRuleHandler());

            foreach (var userData in filteredData.Users)
            {
                var user = mapper.GetUser(userData.Id, filteredData);
                user.TotalAmount = chain.Calculate(user, filteredData, startDate, endDate);
                result.Add(user);
            }

            return result;
        }
    }
}
