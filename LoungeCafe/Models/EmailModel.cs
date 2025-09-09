namespace LoungeCafe.Models
{
    public class EmailModel
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }

    }
}
