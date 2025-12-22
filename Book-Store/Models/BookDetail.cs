using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class BookDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int BookTypeId { get; set; }

        public string Description { get; set; }


        //public string Genres { get; set; }

        public string ReleasedBy { get; set; }

        public DateTime ReleasedAt { get; set; }

        public string Edition { get; set; }

        public int Pages { get; set; }

        public decimal Price { get; set; }  

        public string StockStatus { get; set; }

        public int Stock { get; set; }

        public string FileUrl { get; set; }


        public ICollection<BookDetailGenre> BookDetailGenres { get; set; } = new List<BookDetailGenre>();

    }
}
