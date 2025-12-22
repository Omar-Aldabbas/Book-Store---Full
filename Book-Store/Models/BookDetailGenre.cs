using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Models
{
    public class BookDetailGenre
    {
        [Required]
        public int BookDetailId { get; set; }

        [ForeignKey("BookDetailId")]
        public BookDetail BookDetail { get; set; }
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
