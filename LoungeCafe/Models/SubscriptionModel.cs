namespace LoungeCafe.Models
{
    public class SubscriptionModel
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? Email { get; set; }
        public string? SubscriptionButton { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
