namespace UserDataAPI.Models
{
    using System;

    public class UserPosition
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public int PositionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
