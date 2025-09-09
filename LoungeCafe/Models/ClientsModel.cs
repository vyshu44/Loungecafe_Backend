namespace LoungeCafe.Models
{
    public class ClientsModel
    {
        public int Id { get; set; }
        public required string Image { get; set; }

        public required string Name { get; set; }

        public required string Address { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }


    }
}
