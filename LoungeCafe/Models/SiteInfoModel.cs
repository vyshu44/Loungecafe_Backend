namespace LoungeCafe.Models
{
    public class SiteInfoModel
    {
        public int Id { get; set; }
        public required string SiteName { get; set; }
        public required string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }

    }
}
