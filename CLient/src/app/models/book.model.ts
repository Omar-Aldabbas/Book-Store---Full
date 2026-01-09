export interface Book{
    Id : number,
    Title: string,
    Author: string,
    AddDate: Date,
    MainGenre: string,
    Language: string,
    ThumbnailUrl: string,
    ISBN: string,

}



    // {
    //     [Key]
    //     public int Id { get; set; }
    //     [Required]
        
    //     [MinLength(3)]
    //     public string Title { get; set; }
    //     public string Author { get; set; } = "Unknown";
    //     public DateTime AddDate { get; set; } = DateTime.UtcNow;

    //     public string MainGenre { get; set; } = "General";

    //     public string Language { get; set; } = "English";

    //     public string ThumbnailUrl { get; set; } = "";

    //     [MaxLength(17)]
    //     //[RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Invalid ISBN format")] for real ISBN validation
    //     public string ISBN { get; set; } = "";

    //     // like if each book edition has its won details
    //     public ICollection<BookDetail> BookDetails { get; set; } = new List<BookDetail>();

    // }