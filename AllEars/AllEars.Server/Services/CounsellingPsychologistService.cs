using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public class CounsellingPsychologistService : ICounsellingPsychologistService
    {
        private readonly ICounsellingPsychologistRepository _counsellingPsychologistRepository;

        public CounsellingPsychologistService(ICounsellingPsychologistRepository counsellingPsychologistRepository)
        {
            _counsellingPsychologistRepository = counsellingPsychologistRepository;
        }

        public async Task<List<CounsellingPsychologist>> GetAllCounsellingPsychologists()
        {
            return await _counsellingPsychologistRepository.GetAllCounsellingPsychologists();
        }

        public async Task<CounsellingPsychologist> GetCounsellingPsychologistById(int counsellingPsychologistId)
        {
            return await _counsellingPsychologistRepository.GetCounsellingPsychologistById(counsellingPsychologistId);
        }

        public async Task<bool> CreateCounsellingPsychologist(CounsellingPsychologist counsellingPsychologist)
        {
            return await _counsellingPsychologistRepository.CreateCounsellingPsychologist(counsellingPsychologist);
        }

        public async Task<bool> UpdateCounsellingPsychologist(int id, CounsellingPsychologist counsellingPsychologist)
        {
            return await _counsellingPsychologistRepository.UpdateCounsellingPsychologist(id, counsellingPsychologist);
        }

        public async Task<bool> DeleteCounsellingPsychologist(int counsellingPsychologistId)
        {
            return await _counsellingPsychologistRepository.DeleteCounsellingPsychologist(counsellingPsychologistId);
        }
    }
}
