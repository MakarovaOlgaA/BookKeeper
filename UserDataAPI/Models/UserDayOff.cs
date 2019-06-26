namespace UserDataAPI.Models
{
    using System;

    public class UserDayOff
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int TimeOffTypeId { get; set; }

        public int Total { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
