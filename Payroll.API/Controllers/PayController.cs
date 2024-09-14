using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll.Domain.Entities;
using Payroll.Infrastructure;
using Payroll.Services.Contracts;
using Payroll.Services.Dtos.Pay;
using Payroll.Services.Dtos.PayDetail;
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
            return Ok(pays);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pay>> GePayById(int id)
        {
            try
            {
                var pay = await _payService.GetPayByIdAsync(id);
                return Ok(pay);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddPay(CreatePayDto pay)
        {
            var result = await _payService.AddPayAsync(pay);

            return Ok(result);
        }

        [HttpPut()]
        public async Task<ActionResult> UpdatePay(UpdatePayDto pay)
        {
            try
            {
                await _payService.UpdatePayAsync(pay);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePay(int id)
        {
            try
            {
                await _payService.DeletePayAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


    }
}
