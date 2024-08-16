using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public class ClinicalPsychologistService : IClinicalPsychologistService
    {
        private readonly IClinicalPsychologistRepository _clinicalPsychologistRepository;

        public ClinicalPsychologistService(IClinicalPsychologistRepository clinicalPsychologistRepository)
        {
            _clinicalPsychologistRepository = clinicalPsychologistRepository;
        }

        public async Task<List<ClinicalPsychologist>> GetAllClinicalPsychologists()
        {
            return await _clinicalPsychologistRepository.GetAllClinicalPsychologists();
        }

        public async Task<ClinicalPsychologist> GetClinicalPsychologistById(int clinicalPsychologistId)
        {
            return await _clinicalPsychologistRepository.GetClinicalPsychologistById(clinicalPsychologistId);
        }

        public async Task<bool> CreateClinicalPsychologist(ClinicalPsychologist clinicalPsychologist)
        {
            return await _clinicalPsychologistRepository.CreateClinicalPsychologist(clinicalPsychologist);
        }

        public async Task<bool> UpdateClinicalPsychologist(int id, ClinicalPsychologist clinicalPsychologist)
        {
            return await _clinicalPsychologistRepository.UpdateClinicalPsychologist(id, clinicalPsychologist);
        }

        public async Task<bool> DeleteClinicalPsychologist(int clinicalPsychologistId)
        {
            return await _clinicalPsychologistRepository.DeleteClinicalPsychologist(clinicalPsychologistId);
        }
    }
}
