using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicalDoctorAvailabilityController : ControllerBase
    {
        private readonly IClinicalDoctorAvailabilityService _clinicalDoctorAvailabilityService;

        public ClinicalDoctorAvailabilityController(IClinicalDoctorAvailabilityService clinicalDoctorAvailabilityService)
        {
            _clinicalDoctorAvailabilityService = clinicalDoctorAvailabilityService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            List<ClinicalDoctorAvailability> availabilities = await _clinicalDoctorAvailabilityService.GetAll();
            return Ok(availabilities);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ClinicalDoctorAvailability availability = await _clinicalDoctorAvailabilityService.GetById(id);
            return Ok(availability);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ClinicalDoctorAvailability cl_avail)
        {
            return Ok(await _clinicalDoctorAvailabilityService.Create(cl_avail));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateClinicalDoctorAvailability(int id, [FromBody] ClinicalDoctorAvailability cl_avail)
        {
            var result = await _clinicalDoctorAvailabilityService.Update(id, cl_avail);
            if (result)
            {
                return Ok(new { message = "Availability updated successfully." });
            }
            return BadRequest(new { message = "Failed to update availability." });
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _clinicalDoctorAvailabilityService.Delete(id);
            if (result)
            {
                return Ok(new { message = "Availability deleted successfully." });
            }
            return NotFound(new { message = "Availability not found." });
        }
    }
}
