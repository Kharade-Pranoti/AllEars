using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllEars.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicalPsychologistController : ControllerBase
    {
        private readonly IClinicalPsychologistService _clinicalPsychologistService;

        public ClinicalPsychologistController(IClinicalPsychologistService clinicalPsychologistService)
        {
            _clinicalPsychologistService = clinicalPsychologistService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllClinicalPsychologists()
        {
            var psychologists = await _clinicalPsychologistService.GetAllClinicalPsychologists();
            return Ok(psychologists);
        }

        [HttpGet("getid")]
        public async Task<IActionResult> GetClinicalPsychologistById(int id)
        {
            var psychologist = await _clinicalPsychologistService.GetClinicalPsychologistById(id);
            return Ok(psychologist);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClinicalPsychologist(ClinicalPsychologist psychologist)
        {
            return Ok(await _clinicalPsychologistService.CreateClinicalPsychologist(psychologist));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateClinicalPsychologist(int id, [FromBody] ClinicalPsychologist psychologist)
        {
            var result = await _clinicalPsychologistService.UpdateClinicalPsychologist(id, psychologist);
            if (result)
            {
                return Ok(new { message = "Clinical Psychologist updated successfully." });
            }
            return BadRequest(new { message = "Failed to update Clinical Psychologist." });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClinicalPsychologist(int id)
        {
            var result = await _clinicalPsychologistService.DeleteClinicalPsychologist(id);
            if (result)
            {
                return Ok(new { message = "Clinical Psychologist deleted successfully." });
            }
            return NotFound(new { message = "Clinical Psychologist not found." });
        }
    }
}
