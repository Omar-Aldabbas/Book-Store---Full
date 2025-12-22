namespace Book_Store.Dtos.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime AddDate { get; set; }

        public string MainGenre { get; set; }

        public string Language { get; set; }

        public string ThumbnailUrl { get; set; }

    }
}
