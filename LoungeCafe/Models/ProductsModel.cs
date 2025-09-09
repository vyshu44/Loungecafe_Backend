namespace LoungeCafe.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

	    public required string Item { get; set; }
        public required string Description { get; set; }

        public required string Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
