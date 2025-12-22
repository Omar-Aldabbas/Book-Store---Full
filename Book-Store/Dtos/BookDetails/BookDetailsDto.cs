namespace Book_Store.Dtos.BookDetails
{


        public class BookDetailsDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime AddDate { get; set; }
            public string MainGenre { get; set; }
            public string Language { get; set; }
            public string ThumbnailUrl { get; set; }

            public string Description { get; set; }
            public string ReleasedBy { get; set; }
            public DateTime ReleasedAt { get; set; }
            public string Edition { get; set; }
            public int Pages { get; set; }
            public decimal Price { get; set; }
            public string StockStatus { get; set; }
            public int Stock { get; set; }
            public string FileUrl { get; set; }

            public string BookTypeName { get; set; }
            public List<string> Genres { get; set; } = new();
        }

}
