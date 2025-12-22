using System.ComponentModel.DataAnnotations;

namespace Book_Store.Dtos.BookDetails
{
    public class UpdateBookDetailsDto
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int BookTypeId { get; set; }
        public string Description { get; set; }
        public string ReleasedBy { get; set; }
        public DateTime ReleasedAt { get; set; } = DateTime.UtcNow;
        public string Edition { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public string StockStatus { get; set; }
        public int Stock { get; set; }
        public IFormFile File { get; set; }
        public List<int> GenreIds { get; set; } = new();
    }
}
