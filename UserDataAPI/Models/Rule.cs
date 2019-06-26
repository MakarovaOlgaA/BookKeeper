namespace UserDataAPI.Models
{
    using System;

    public class Rule
    {
        public long Id { get; set; }

        public long RuleTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Bonus { get; set; }
    }
}
