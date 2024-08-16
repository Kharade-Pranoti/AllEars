using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
    public interface ICounsellingPsychologistRepository
    {
        Task<List<CounsellingPsychologist>> GetAllCounsellingPsychologists();
        Task<CounsellingPsychologist> GetCounsellingPsychologistById(int counselling_psychologist_id);
        Task<bool> CreateCounsellingPsychologist(CounsellingPsychologist counsellingPsychologist);
        Task<bool> UpdateCounsellingPsychologist(int id, CounsellingPsychologist counsellingPsychologist);
        Task<bool> DeleteCounsellingPsychologist(int counselling_psychologist_id);
    }
}
