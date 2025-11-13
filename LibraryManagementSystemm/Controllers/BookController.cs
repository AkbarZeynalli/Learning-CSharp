using LibraryManagementSystemm.Dtos;
using LibraryManagementSystemm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        
        [HttpPost]
        public async Task<ActionResult> Create(BookDto dto)
        {
            await _bookService.AddAsync(dto);
            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BookDto dto)
        {
            await _bookService.UpdateAsync(id, dto);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
