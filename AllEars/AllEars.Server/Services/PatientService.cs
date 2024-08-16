using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAllPatient();
        }

        public async Task<Patient> GetPatientById(int patient_id)
        {
            return await _patientRepository.GetPatientById(patient_id);
        }

        public async Task<bool> Delete(int patient_id)
        {
            return await _patientRepository.Delete(patient_id);
        }

        public async Task<bool> CreatePatient(Patient patient)
        {
            return await _patientRepository.Insert(patient);
        }

        public async Task<bool> UpdatePatient(int patient_id, Patient patient)
        {
            return await _patientRepository.Update(patient_id, patient);
        }
    }
}
