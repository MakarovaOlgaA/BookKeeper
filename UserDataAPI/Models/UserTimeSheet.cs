namespace UserDataAPI.Models
{
    using System;

    public class UserTimeSheet
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public int Hours { get; set; }
    }
}
