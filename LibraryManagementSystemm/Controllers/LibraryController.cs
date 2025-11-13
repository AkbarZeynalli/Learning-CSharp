using LibraryManagementSystemm.Dtos;
using LibraryManagementSystemm.Models;
using LibraryManagementSystemm.Repository;
using LibraryManagementSystemm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryDto>>> GetAll()
        {
         var list= await _libraryService.GetAllAsync();

            return Ok(list);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryDto>> GetById(int id)
        {
            var libDto = _libraryService.GetByIdAsync(id);

            return Ok(libDto);
        }


        [HttpPost]
        public async Task<ActionResult> Create(LibraryDto dto)
        {
            await _libraryService.AddAsync(dto);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, LibraryDto dto)
        {
            await _libraryService.UpdateAsync(id,dto);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _libraryService.DeleteAsync(id);


            return NoContent();
        }
    }
}
