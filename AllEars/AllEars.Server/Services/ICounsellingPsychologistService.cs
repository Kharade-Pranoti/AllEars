using AllEars.Server.Entities;

namespace AllEars.Server.Services
{
    public interface ICounsellingPsychologistService
    {
        Task<List<CounsellingPsychologist>> GetAllCounsellingPsychologists();
        Task<CounsellingPsychologist> GetCounsellingPsychologistById(int counsellingPsychologistId);
        Task<bool> CreateCounsellingPsychologist(CounsellingPsychologist counsellingPsychologist);
        Task<bool> UpdateCounsellingPsychologist(int id, CounsellingPsychologist counsellingPsychologist);
        Task<bool> DeleteCounsellingPsychologist(int counsellingPsychologistId);
    }
}
