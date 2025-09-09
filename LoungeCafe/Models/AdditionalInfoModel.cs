namespace LoungeCafe.Models
{
    public class AdditionalInfoModel
    {
        public int Id { get; set; }
        public required string Copyright { get; set; }
        public required string Design { get; set; }
        public required string Distribution { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
