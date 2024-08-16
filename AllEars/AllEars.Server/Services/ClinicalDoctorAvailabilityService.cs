using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public class ClinicalDoctorAvailabilityService : IClinicalDoctorAvailabilityService
    {
        private readonly IClinicalDoctorAvailabilityRepository _availabilityRepository;

        public ClinicalDoctorAvailabilityService(IClinicalDoctorAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<List<ClinicalDoctorAvailability>> GetAll()
        {
            return await _availabilityRepository.GetAll();
        }

        public async Task<ClinicalDoctorAvailability> GetById(int id)
        {
            return await _availabilityRepository.GetById(id);
        }

        public async Task<bool> Create(ClinicalDoctorAvailability cl_avail)
        {
            return await _availabilityRepository.Create(cl_avail);
        }

        public async Task<bool> Update(int id, ClinicalDoctorAvailability cl_avail)
        {
            return await _availabilityRepository.Update(id, cl_avail);
        }

        public async Task<bool> Delete(int id)
        {
            return await _availabilityRepository.Delete(id);
        }
    }
}
