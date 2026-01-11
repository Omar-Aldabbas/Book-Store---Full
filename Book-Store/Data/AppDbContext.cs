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

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Language)
                .WithMany(l => l.Books)
                .HasForeignKey(b => b.LanguageId);



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


            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookDetails)
                .WithOne(d => d.Book)
                .HasForeignKey<BookDetail>(d => d.BookId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
