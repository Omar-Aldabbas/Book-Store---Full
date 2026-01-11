using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Book_Store.Dtos.BookDetails
{
    public class BookDetailsDto
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int BookTypeId { get; set; }

        public string? Description { get; set; }
        public string? ReleasedBy { get; set; }
        public DateTime ReleasedAt { get; set; } = DateTime.UtcNow;
        public string? Edition { get; set; }

        [Range(1, int.MaxValue)]
        public int Pages { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        public string? StockStatus { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public string FileUrl { get; set; }

        public List<int> GenreIds { get; set; } = new();
    }
}
