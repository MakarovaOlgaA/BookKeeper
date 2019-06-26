namespace UserDataAPI.Models
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public int RateTypeId { get; set; }
    }
}
