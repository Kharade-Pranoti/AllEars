using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllEars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounsellingPsychologistController : ControllerBase
    {
        private readonly ICounsellingPsychologistService _counsellingPsychologistService;

        public CounsellingPsychologistController(ICounsellingPsychologistService counsellingPsychologistService)
        {
            _counsellingPsychologistService = counsellingPsychologistService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllCounsellingPsychologists()
        {
            var psychologists = await _counsellingPsychologistService.GetAllCounsellingPsychologists();
            return Ok(psychologists);
        }

        [HttpGet("getid")]
        public async Task<IActionResult> GetCounsellingPsychologistById(int id)
        {
            var psychologist = await _counsellingPsychologistService.GetCounsellingPsychologistById(id);
            return Ok(psychologist);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCounsellingPsychologist(CounsellingPsychologist psychologist)
        {
            return Ok(await _counsellingPsychologistService.CreateCounsellingPsychologist(psychologist));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCounsellingPsychologist(int id, [FromBody] CounsellingPsychologist psychologist)
        {
            var result = await _counsellingPsychologistService.UpdateCounsellingPsychologist(id, psychologist);
            if (result)
            {
                return Ok(new { message = "Counselling Psychologist updated successfully." });
            }
            return BadRequest(new { message = "Failed to update Counselling Psychologist." });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCounsellingPsychologist(int id)
        {
            var result = await _counsellingPsychologistService.DeleteCounsellingPsychologist(id);
            if (result)
            {
                return Ok(new { message = "Counselling Psychologist deleted successfully." });
            }
            return NotFound(new { message = "Counselling Psychologist not found." });
        }
    }
}
