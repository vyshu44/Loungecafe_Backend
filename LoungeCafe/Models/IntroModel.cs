namespace LoungeCafe.Models
{
    public class IntroModel
    {
        public int Id { get; set; }
        public required string Greet { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
