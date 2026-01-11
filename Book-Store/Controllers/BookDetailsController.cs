using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book_Store.Data;
using Book_Store.Models;
using Book_Store.Dtos.BookDetails;
using Book_Store.Services.Interfaces;


namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFileStorageService _fileService;

        public BookDetailsController(AppDbContext context, IFileStorageService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: api/BookDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetailsDto>>> GetBookDetails()
        {
            var books = await _context.BookDetails
                .Include(d => d.Book)
                .Include(d => d.BookType)
                .Include(d => d.BookDetailGenres)
                    .ThenInclude(bg => bg.Genre)
                .ToListAsync();

            var dtoList = books.Select(d => new BookDetailsDto
            {
                Id = d.Id,
                Description = d.Description,
                ReleasedBy = d.ReleasedBy,
                ReleasedAt = d.ReleasedAt,
                Edition = d.Edition,
                Pages = d.Pages,
                Price = d.Price,
                StockStatus = d.StockStatus,
                Stock = d.Stock,
                FileUrl = d.FileUrl,
                GenreIds = d.BookDetailGenres.Select(bg => bg.Genre.Id).ToList()
            }).ToList();

            return Ok(dtoList);
        }

        // GET: api/BookDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDto>> GetBookDetail(int id)
        {
            var bookDetail = await _context.BookDetails
                .Include(d => d.Book)
                .Include(d => d.BookType)
                .Include(d => d.BookDetailGenres)
                    .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (bookDetail == null)
                return NotFound();

            var dtoBook = new BookDetailsDto
            {
                Id = bookDetail.Id,
                Description = bookDetail.Description,
                ReleasedBy = bookDetail.ReleasedBy,
                ReleasedAt = bookDetail.ReleasedAt,
                Edition = bookDetail.Edition,
                Pages = bookDetail.Pages,
                Price = bookDetail.Price,
                StockStatus = bookDetail.StockStatus,
                Stock = bookDetail.Stock,
                FileUrl = bookDetail.FileUrl,
                GenreIds = bookDetail.BookDetailGenres.Select(bg => bg.Genre.Id).ToList()
                
            };

            return Ok(dtoBook);
        }

        // PUT: api/BookDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookDetail(int id, UpdateBookDetailsDto dto)
        {
            var bookDetail = await _context.BookDetails
                .Include(d => d.Book)
                .Include(d => d.BookType)
                .Include(d => d.BookDetailGenres)
                    .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (bookDetail == null)
                return NotFound();

            // Handle file upload
            if (dto.File != null)
            {
                // Delete old file if exists
                _fileService.DeleteFile(bookDetail.FileUrl);

                // Save new file and update URL
                bookDetail.FileUrl = await _fileService.SaveFileAsync(dto.File, "books");
            }

            // Update scalar properties
            bookDetail.Description = dto.Description;
            bookDetail.Edition = dto.Edition;
            bookDetail.Pages = dto.Pages;
            bookDetail.Price = dto.Price;
            bookDetail.StockStatus = dto.StockStatus;
            bookDetail.Stock = dto.Stock;
            bookDetail.BookTypeId = dto.BookTypeId;

            // Update genres (many-to-many)
            bookDetail.BookDetailGenres.Clear();
            foreach (var genreId in dto.GenreIds)
            {
                bookDetail.BookDetailGenres.Add(new BookDetailGenre
                {
                    BookDetailId = bookDetail.Id,
                    GenreId = genreId
                });
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.BookDetails.Any(d => d.Id == id))
                    return NotFound();
                else
                    throw;
            }

            var updatedDto = new BookDetailsDto
            {
                Id = bookDetail.Id,
                Description = bookDetail.Description,
                ReleasedBy = bookDetail.ReleasedBy,
                ReleasedAt = bookDetail.ReleasedAt,
                Edition = bookDetail.Edition,
                Pages = bookDetail.Pages,
                Price = bookDetail.Price,
                StockStatus = bookDetail.StockStatus,
                Stock = bookDetail.Stock,
                FileUrl = bookDetail.FileUrl,
                GenreIds = bookDetail.BookDetailGenres.Select(bg => bg.Genre.Id).ToList()
            };

            return Ok(updatedDto);
        }

        // POST: api/BookDetails
        [HttpPost]
        public async Task<ActionResult<BookDetailsDto>> PostBookDetail(CreateBookDetailsDto dto)
        {
            var bookDetail = new BookDetail
            {
                BookId = dto.BookId,
                BookTypeId = dto.BookTypeId,
                Description = dto.Description,
                ReleasedBy = dto.ReleasedBy,
                ReleasedAt = dto.ReleasedAt,
                Edition = dto.Edition,
                Pages = dto.Pages,
                Price = dto.Price,
                StockStatus = dto.StockStatus,
                Stock = dto.Stock
            };

            // Save file if uploaded
            if (dto.File != null)
            {
                bookDetail.FileUrl = await _fileService.SaveFileAsync(dto.File, "books");
            }

            foreach (var genreId in dto.GenreIds)
            {
                bookDetail.BookDetailGenres.Add(new BookDetailGenre
                {
                    GenreId = genreId
                });
            }

            _context.BookDetails.Add(bookDetail);
            await _context.SaveChangesAsync();

            await _context.Entry(bookDetail).Reference(d => d.Book).LoadAsync();
            await _context.Entry(bookDetail).Reference(d => d.BookType).LoadAsync();
            await _context.Entry(bookDetail).Collection(d => d.BookDetailGenres).Query()
                .Include(bg => bg.Genre)
                .LoadAsync();

            var dtoBook = new BookDetailsDto
            {
                Id = bookDetail.Id,
                Description = bookDetail.Description,
                ReleasedBy = bookDetail.ReleasedBy,
                ReleasedAt = bookDetail.ReleasedAt,
                Edition = bookDetail.Edition,
                Pages = bookDetail.Pages,
                Price = bookDetail.Price,
                StockStatus = bookDetail.StockStatus,
                Stock = bookDetail.Stock,
                FileUrl = bookDetail.FileUrl,
                GenreIds = bookDetail.BookDetailGenres.Select(bg => bg.Genre.Id).ToList()
            };

            return CreatedAtAction(nameof(GetBookDetail), new { id = bookDetail.Id }, dtoBook);
        }

        // DELETE: api/BookDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookDetail(int id)
        {
            var bookDetail = await _context.BookDetails.FindAsync(id);
            if (bookDetail == null)
                return NotFound();

            // Delete associated file if exists
            if (!string.IsNullOrEmpty(bookDetail.FileUrl))
            {
                _fileService.DeleteFile(bookDetail.FileUrl);
            }

            _context.BookDetails.Remove(bookDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookDetailExists(int id) => _context.BookDetails.Any(e => e.Id == id);
    }
}
