using AllEars.Server.Entities;


namespace AllEars.Server.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatient();

        Task<Patient> GetPatientById(int patient_id);

        Task<bool> Delete(int patient_id);

        Task<bool> Insert(Patient patient);

        Task<bool> Update(int patient_id, Patient patient);

        Task<Patient> GetPatientByEmailAndPassword(string email, string password);

    }
}
