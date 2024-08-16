using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounsellingDoctorAvailabilityController : ControllerBase
    {
        private readonly ICounsellingDoctorAvailabilityService _counsellingDoctorAvailabilityService;

        public CounsellingDoctorAvailabilityController(ICounsellingDoctorAvailabilityService counsellingDoctorAvailabilityService)
        {
            _counsellingDoctorAvailabilityService = counsellingDoctorAvailabilityService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            List<CounsellingDoctorAvailability> availabilities = await _counsellingDoctorAvailabilityService.GetAll();
            return Ok(availabilities);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var availability = await _counsellingDoctorAvailabilityService.GetById(id);
            if (availability == null)
            {
                return NotFound(new { message = "Availability not found." });
            }
            return Ok(availability);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CounsellingDoctorAvailability co_avail)
        {
            if (co_avail == null)
            {
                return BadRequest(new { message = "Invalid availability data." });
            }

            var result = await _counsellingDoctorAvailabilityService.Create(co_avail);
            if (result)
            {
                return CreatedAtAction(nameof(GetById), new { id = co_avail.co_availability_id }, co_avail);
            }

            return BadRequest(new { message = "Failed to create availability." });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CounsellingDoctorAvailability co_avail)
        {
            if (co_avail == null || id != co_avail.co_availability_id)
            {
                return BadRequest(new { message = "Invalid availability data." });
            }

            var result = await _counsellingDoctorAvailabilityService.Update(id, co_avail);
            if (result)
            {
                return Ok(new { message = "Availability updated successfully." });
            }

            return NotFound(new { message = "Availability not found." });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _counsellingDoctorAvailabilityService.Delete(id);
            if (result)
            {
                return Ok(new { message = "Availability deleted successfully." });
            }

            return NotFound(new { message = "Availability not found." });
        }
    }
}
