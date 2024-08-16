using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public class CounsellingDoctorAvailabilityService : ICounsellingDoctorAvailabilityService
    {
        private readonly ICounsellingDoctorAvailabilityRepository _counsellingDoctorAvailabilityRepository;

        public CounsellingDoctorAvailabilityService(ICounsellingDoctorAvailabilityRepository counsellingDoctorAvailabilityRepository)
        {
            _counsellingDoctorAvailabilityRepository = counsellingDoctorAvailabilityRepository;
        }

        public async Task<List<CounsellingDoctorAvailability>> GetAll()
        {
            return await _counsellingDoctorAvailabilityRepository.GetAll();
        }

        public async Task<CounsellingDoctorAvailability> GetById(int id)
        {
            return await _counsellingDoctorAvailabilityRepository.GetById(id);
        }

        public async Task<bool> Create(CounsellingDoctorAvailability co_avail)
        {
            return await _counsellingDoctorAvailabilityRepository.Create(co_avail);
        }

        public async Task<bool> Update(int id, CounsellingDoctorAvailability co_avail)
        {
            return await _counsellingDoctorAvailabilityRepository.Update(id, co_avail);
        }

        public async Task<bool> Delete(int id)
        {
            return await _counsellingDoctorAvailabilityRepository.Delete(id);
        }
    }
}
