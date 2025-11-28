using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Services;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAll()
        {
            var books = await _paymentService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetById(int id)
        {
            var customer = await _paymentService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PaymentDto dto)
        {
            await _paymentService.AddAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PaymentDto dto)
        {
            await _paymentService.UpdateAsync(id, dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _paymentService.DeleteAsync(id);
            return Ok();
        }
    }
}
