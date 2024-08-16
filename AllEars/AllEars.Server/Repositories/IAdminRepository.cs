using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAdmin();
        Task<Admin> GetAdminById(int admin_id);
        Task<bool> CreateAdmin(Admin admin);
        Task<bool> UpdateAdmin(int id, Admin admin);
        Task<bool> DeleteAdmin(int admin_id);
        Task<Admin> GetAdminByEmailAndPassword(string email, string password);


    }
}
