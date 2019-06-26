namespace UserDataAPI.Models
{
    using System;

    public class UserTimeOff
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public int TimeOffTypeId { get; set; }

    }
}
