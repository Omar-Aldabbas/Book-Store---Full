using System.ComponentModel.DataAnnotations;

namespace Book_Store.Dtos.BookTypes
{
    public class CreateBookTypeDto
    {
        [Required]
        public string TypeName { get; set; }
    }
}
