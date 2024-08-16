using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
    public interface IClinicalDoctorAvailabilityRepository
    {
        Task<List<ClinicalDoctorAvailability>> GetAll();
        Task<ClinicalDoctorAvailability> GetById(int id);
        Task<bool> Create(ClinicalDoctorAvailability cl_avail);
        Task<bool> Update(int id, ClinicalDoctorAvailability cl_avail);
        Task<bool> Delete(int id);
    }
}
