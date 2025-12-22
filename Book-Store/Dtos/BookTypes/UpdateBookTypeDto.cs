using System.ComponentModel.DataAnnotations;

namespace Book_Store.Dtos.BookTypes
{
    public class UpdateBookTypeDto
    {
        [Required]
        public string TypeName { get; set; }
    }
}
