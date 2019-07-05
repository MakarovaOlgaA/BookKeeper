namespace BookKeeper
{
    using System;
    using System.Collections.Generic;
    using UserDataAPI.Models;

    public class HourlyBaseRateCalculator : IBaseRateCalculator
    {
        public HourlyBaseRateCalculator(IEnumerable<UserTimeSheet> timeSheets)
        {

        }

        public decimal Calculate(decimal rate, DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }
    }
}
