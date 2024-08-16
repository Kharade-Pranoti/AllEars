using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAppointmentController : ControllerBase
    {
        private readonly IBookAppointmentService _bookAppointmentService;

        public BookAppointmentController(IBookAppointmentService bookAppointmentService)
        {
            _bookAppointmentService = bookAppointmentService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllAppointments()
        {
            List<BookAppointment> appointments = await _bookAppointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpGet("getid")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            BookAppointment appointment = await _bookAppointmentService.GetAppointmentById(id);
            return Ok(appointment);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment(BookAppointment appointment)
        {
           
                return Ok(await _bookAppointmentService.CreateAppointment(appointment));

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] BookAppointment appointment)
        {
            var result = await _bookAppointmentService.UpdateAppointment(id, appointment);
            if (result)
            {
                return Ok(new { message = "Appointment updated successfully." });
            }
            return BadRequest(new { message = "Failed to update appointment." });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await _bookAppointmentService.DeleteAppointment(id);
            if (result)
            {
                return Ok(new { message = "Appointment deleted successfully." });
            }
            return NotFound(new { message = "Appointment not found." });
        }
    }
}
