using System.Collections.Generic;

namespace BookKeeper.Models
{
    public class UserResultVM
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal TotalAmount { get; set; }

        public VacationInfoVM VacationInfo { get; set; }

        public IEnumerable<TimeSheetVM> TimeSheets { get; set; }

        public IEnumerable<UserPositionVM> Positions { get; set; }

    }
}
