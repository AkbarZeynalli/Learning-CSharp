using LibraryManagementSystemm.Dtos;
using LibraryManagementSystemm.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRecordController : ControllerBase
    {
        private readonly IBorrowRecordService _borrowRecordService;

        public BorrowRecordController(IBorrowRecordService borrowRecordService)
        {
            _borrowRecordService = borrowRecordService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowRecordDto>>> GetAll()
        {
            var records = await _borrowRecordService.GetAllAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowRecordDto>> GetById(int id)
        {
            var record = await _borrowRecordService.GetByIdAsync(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult> Create(BorrowRecordDto dto)
        {
            await _borrowRecordService.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BorrowRecordDto dto)
        {
            await _borrowRecordService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _borrowRecordService.DeleteAsync(id);
            return NoContent();
        }
    }
}
