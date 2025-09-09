namespace LoungeCafe.Models
{
    public class GalleryModel
    {
        public int Id { get; set; }
        public required string Image { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
