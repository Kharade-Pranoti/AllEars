using AllEars.Server.Entities;

namespace AllEars.Server.Services
{
    public interface ICounsellingDoctorAvailabilityService
    {
        Task<List<CounsellingDoctorAvailability>> GetAll();
        Task<CounsellingDoctorAvailability> GetById(int id);
        Task<bool> Create(CounsellingDoctorAvailability co_avail);
        Task<bool> Update(int id, CounsellingDoctorAvailability co_avail);
        Task<bool> Delete(int id);

    }
}
