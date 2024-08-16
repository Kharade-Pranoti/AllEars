using AllEars.Server.Entities;

namespace AllEars.Server.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int patient_id);

        Task<bool> Delete(int patient_id);

        Task<bool> CreatePatient(Patient patient);

        Task<bool> UpdatePatient(int patient_id, Patient patient);
    }
}
