using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LanguageName { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
