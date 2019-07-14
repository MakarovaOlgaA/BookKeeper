namespace BookKeeper.Models
{
    using System;

    public class UserPositionVM
    {
        public int PositionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int Hours { get; set; }
    }
}
