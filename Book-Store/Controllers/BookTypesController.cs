using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book_Store.Data;
using Book_Store.Models;

namespace Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BookTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookType>>> GetBookTypes()
        {
            return await _context.BookTypes.ToListAsync();
        }

        // GET: api/BookTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookType>> GetBookType(int id)
        {
            var bookType = await _context.BookTypes.FindAsync(id);

            if (bookType == null)
            {
                return NotFound();
            }

            return bookType;
        }

        // PUT: api/BookTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookType(int id, BookType bookType)
        {
            if (id != bookType.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookType>> PostBookType(BookType bookType)
        {
            _context.BookTypes.Add(bookType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookType", new { id = bookType.Id }, bookType);
        }

        // DELETE: api/BookTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookType(int id)
        {
            var bookType = await _context.BookTypes.FindAsync(id);
            if (bookType == null)
            {
                return NotFound();
            }

            _context.BookTypes.Remove(bookType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookTypeExists(int id)
        {
            return _context.BookTypes.Any(e => e.Id == id);
        }
    }
}
