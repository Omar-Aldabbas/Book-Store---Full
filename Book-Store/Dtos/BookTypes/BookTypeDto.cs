using System.ComponentModel.DataAnnotations;

namespace Book_Store.Dtos.BookTypes
{
    public class BookTypeDto
    {
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
