namespace BookKeeper.Models
{
    public class UserResultVM
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal TotalAmount { get; set; }

        public VacationInfoVM VacationInfo { get; set; }
    }
}
