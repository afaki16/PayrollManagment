using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll.Domain.Entities;
using Payroll.Services.Contracts;
using Payroll.Services.Dtos.Pay;
using Payroll.Services.Services;

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pay>>> GetAllPays()
        {
            var pays = await _payService.GetAllPayAsync();

            if (pays == null || !pays.Any())
            {
                return NoContent(); 
            }

            return Ok(pays); 
        }

        [HttpGet("GetAllEmployeePays")]
        public async Task<ActionResult<IEnumerable<Pay>>> GetAllEmployeePays()
        {
            var pays = await _payService.GetAllEmployeePaysAsync();

            if (pays == null || !pays.Any())
            {
                return NoContent(); 
            }

            return Ok(pays); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pay>> GetPayById(int id)
        {
            try
            {
                var pay = await _payService.GetPayByIdAsync(id);

                if (pay == null)
                {
                    return NotFound(new { Message = $"Pay with ID {id} not found" }); 
                }

                return Ok(pay); // 200: Başarılı, ödeme döner
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Pay with ID {id} not found" }); 
            }
        }

        // Add a new Pay
        [HttpPost]
        public async Task<ActionResult> AddPay(CreatePayDto pay)
        {
            var result = await _payService.AddPayAsync(pay);

            if (result != null)
            {
                return CreatedAtAction(nameof(GetPayById), new { id = result.Id }, result); 
            }

            return BadRequest(new { Message = "Failed to add pay" }); 
        }

        // Update an existing Pay
        [HttpPut()]
        public async Task<ActionResult> UpdatePay(UpdatePayDto pay)
        {
            try
            {
                await _payService.UpdatePayAsync(pay);
                return Ok(new { Message = "Pay updated successfully" }); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Pay with ID {pay.Id} not found" }); 
            }
        }

        // Delete a Pay
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePay(int id)
        {
            try
            {
                await _payService.DeletePayAsync(id);
                return Ok(new { Message = $"Pay with ID {id} deleted successfully" }); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Pay with ID {id} not found" });
            }
        }
    }
}
