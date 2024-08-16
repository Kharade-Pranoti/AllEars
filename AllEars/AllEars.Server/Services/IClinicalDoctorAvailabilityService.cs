using AllEars.Server.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public interface IClinicalDoctorAvailabilityService
    {
        Task<List<ClinicalDoctorAvailability>> GetAll();
        Task<ClinicalDoctorAvailability> GetById(int id);
        Task<bool> Create(ClinicalDoctorAvailability cl_avail);
        Task<bool> Update(int id, ClinicalDoctorAvailability cl_avail);
        Task<bool> Delete(int id);
    }
}
