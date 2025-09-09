using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace LoungeCafe.Models
{
    public class NavLinksModel
    {
        public int Id { get; set; }
        public required string Label { get; set; }

        public required string Href { get; set; }
        public int? SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}
