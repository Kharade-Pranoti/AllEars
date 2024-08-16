using AllEars.Server.Entities;

namespace AllEars.Server.Services
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAllAdmin();
        Task<Admin> GetAdminById(int adminId);
        Task<bool> CreateAdmin(Admin admin);
        Task<bool> UpdateAdmin(int id, Admin admin);
        Task<bool> DeleteAdmin(int adminId);
    }
}
