using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
    public interface IClinicalPsychologistRepository
    {
        Task<List<ClinicalPsychologist>> GetAllClinicalPsychologists();
        Task<ClinicalPsychologist> GetClinicalPsychologistById(int clinical_psychologist_id);
        Task<bool> CreateClinicalPsychologist(ClinicalPsychologist clinicalPsychologist);
        Task<bool> UpdateClinicalPsychologist(int id, ClinicalPsychologist clinicalPsychologist);
        Task<bool> DeleteClinicalPsychologist(int clinical_psychologist_id);
    }
}
