using AllEars.Server.Entities;

namespace AllEars.Server.Services
{
    public interface IClinicalPsychologistService
    {
        Task<List<ClinicalPsychologist>> GetAllClinicalPsychologists();
        Task<ClinicalPsychologist> GetClinicalPsychologistById(int clinicalPsychologistId);
        Task<bool> CreateClinicalPsychologist(ClinicalPsychologist clinicalPsychologist);
        Task<bool> UpdateClinicalPsychologist(int id, ClinicalPsychologist clinicalPsychologist);
        Task<bool> DeleteClinicalPsychologist(int clinicalPsychologistId);
    }
}
