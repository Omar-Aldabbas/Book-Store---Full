namespace Book_Store.Dtos.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime AddDate { get; set; }

        public string MainGenre { get; set; }

        public int LanguageId { get; set; }

        public string ThumbnailUrl { get; set; }

    }
}
