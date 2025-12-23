using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Dtos.Books;
using Book_Store.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFileStorageService _fileService;

        public BooksController(AppDbContext context, IFileStorageService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _context.Books
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    AddDate = b.AddDate,
                    MainGenre = b.MainGenre,
                    Language = b.Language,
                    ThumbnailUrl = b.ThumbnailUrl
                })
                .ToListAsync();

            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            var dto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                AddDate = book.AddDate,
                MainGenre = book.MainGenre,
                Language = book.Language,
                ThumbnailUrl = book.ThumbnailUrl
            };

            return Ok(dto);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> PutBook(int id, UpdateBookDto dto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            // Handle new thumbnail if uploaded
            if (dto.Thumbnail != null)
            {
                if (!string.IsNullOrEmpty(book.ThumbnailUrl))
                {
                    _fileService.DeleteFile(book.ThumbnailUrl);
                }

                book.ThumbnailUrl = await _fileService.SaveImageAsync(dto.Thumbnail, "books");
            }

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.MainGenre = dto.MainGenre;
            book.Language = dto.Language;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(b => b.Id == id))
                    return NotFound();
                else
                    throw;
            }

            var updatedDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                MainGenre = book.MainGenre,
                Language = book.Language,
                ThumbnailUrl = book.ThumbnailUrl,
                AddDate = book.AddDate
            };

            return Ok(updatedDto);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(CreateBookDto dto)
        {
            string thumbnailUrl = null;

            if (dto.Thumbnail != null)
            {
                thumbnailUrl = await _fileService.SaveImageAsync(dto.Thumbnail, "books");
            }

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                MainGenre = dto.MainGenre,
                Language = dto.Language,
                ThumbnailUrl = thumbnailUrl
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var resultDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                AddDate = book.AddDate,
                MainGenre = book.MainGenre,
                Language = book.Language,
                ThumbnailUrl = book.ThumbnailUrl
            };

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, resultDto);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            if (!string.IsNullOrEmpty(book.ThumbnailUrl))
            {
                _fileService.DeleteFile(book.ThumbnailUrl);
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("newest")]
        public async Task<ActionResult<BookDto>> GetNewestBook()
        {
            var book = await _context.Books
                .OrderByDescending(b => b.AddDate)
                .FirstOrDefaultAsync();

            if (book == null)
                return NotFound();

            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                AddDate = book.AddDate,
                MainGenre = book.MainGenre,
                Language = book.Language,
                ThumbnailUrl = book.ThumbnailUrl
            };

            return Ok(bookDto);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
