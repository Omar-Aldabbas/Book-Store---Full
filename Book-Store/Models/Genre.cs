using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Book_Store.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; }

        public ICollection<BookDetailGenre> BookDetailGenres { get; set; } = new List<BookDetailGenre>();
    }
}
