using Book_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookDetailGenre> BookDetailGenres { get; set; }

        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Book fluent
            // Book -> Language
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Language)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LanguageId);
            // Book -> BookDetail
            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookDetails)
                .WithOne(d => d.Book)
                .HasForeignKey<BookDetail>(d => d.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Book -> Author
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId)
    .OnDelete(DeleteBehavior.Restrict);

            #endregion

            modelBuilder.Entity<BookDetailGenre>()
                .HasKey(bdg => new { bdg.BookDetailId, bdg.GenreId });

            modelBuilder.Entity<BookDetailGenre>()
                .HasOne(bdg => bdg.BookDetail)
                .WithMany(bd => bd.BookDetailGenres)
                .HasForeignKey(bdg => bdg.BookDetailId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookDetailGenre>()
                .HasOne(bdg => bdg.Genre)
                .WithMany(g => g.BookDetailGenres)
                .HasForeignKey(bdg => bdg.GenreId)
                .OnDelete(DeleteBehavior.Restrict);



        }

    }
}
