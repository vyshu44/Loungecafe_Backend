namespace LoungeCafe.Models
{
    public class IconsModel
    {
        public int Id { get; set; }

        public int FooterId { get; set; }
	    public required string Icon { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
