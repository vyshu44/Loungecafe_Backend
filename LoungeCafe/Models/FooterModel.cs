namespace LoungeCafe.Models
{
    public class FooterModel
    {
        public int Id { get; set; }
        public required string Location { get; set; }
        public required string ContactEmail { get; set; }
        public required string ContactPhone { get; set; }
        public TimeSpan WeekDayStart { get; set; }

        public TimeSpan WeekDayEnd { get; set; }
        public TimeSpan WeekEndStart { get; set; }
        public TimeSpan WeekEndEnd { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }

    }
}
