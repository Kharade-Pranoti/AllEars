using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllBillings()
        {
            List<Billing> billings = await _billingService.GetAllBillings();
            return Ok(billings);
        }

        [HttpGet("getid")]
        public async Task<IActionResult> GetBillingById(int id)
        {
            Billing billing = await _billingService.GetBillingById(id);
            return Ok(billing);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBilling(Billing billing)
        {
            return Ok(await _billingService.CreateBilling(billing));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBilling(int id, [FromBody] Billing billing)
        {
            var result = await _billingService.UpdateBilling(id, billing);
            if (result)
            {
                return Ok(new { message = "Billing updated successfully." });
            }
            return BadRequest(new { message = "Failed to update billing." });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBilling(int id)
        {
            var result = await _billingService.DeleteBilling(id);
            if (result)
            {
                return Ok(new { message = "Billing deleted successfully." });
            }
            return NotFound(new { message = "Billing not found." });
        }
    }
}
