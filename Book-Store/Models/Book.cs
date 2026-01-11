using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        [MinLength(3)]
        public string Title { get; set; }
        public string Author { get; set; } = "Unknown";
        public DateTime AddDate { get; set; } = DateTime.UtcNow;

        public string MainGenre { get; set; } = "General";

        [ForeignKey("Language")]
        [Required]
        public int LanguageId { get; set; }

        public string ThumbnailUrl { get; set; } = "";

        [MaxLength(17)]
        //[RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Invalid ISBN format")] for real ISBN validation
        public string ISBN { get; set; } = "";

        // like if each book edition has its won details
        public BookDetail BookDetails { get; set; }

        public Language Language { get; set; }

        }
}
