using AllEars.Server.Entities;
using AllEars.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/patient
        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatients();
            return Ok(patients);
        }

        // GET: api/patient/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound(); // Return 404 if the patient is not found
            }
            return Ok(patient);
        }

        // POST: api/patient
        [HttpPost]
        public async Task<ActionResult> CreatePatient(Patient patient)
        {
            var result = await _patientService.CreatePatient(patient);
            if (result)
            {
                return CreatedAtAction(nameof(GetPatientById), new { id = patient.patient_id }, patient);
            }
            return BadRequest("Unable to create patient");
        }

        // PUT: api/patient/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, Patient patient)
        {
            if (id != patient.patient_id)
            {
                return BadRequest("Patient ID mismatch");
            }

            var result = await _patientService.UpdatePatient(id, patient);
            if (result)
            {
                return NoContent(); // Return 204 No Content on successful update
            }
            return NotFound(); // Return 404 if the patient is not found
        }

        // DELETE: api/patient/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var result = await _patientService.Delete(id);
            if (result)
            {
                return NoContent(); // Return 204 No Content on successful deletion
            }
            return NotFound(); // Return 404 if the patient is not found
        }
    }
}
