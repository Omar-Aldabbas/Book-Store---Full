namespace Book_Store.Dtos.Books
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime AddDate { get; set; }

        public string MainGenre { get; set; }

        public int LanguageId { get; set; }

        public IFormFile Thumbnail { get; set; }

    }
}
