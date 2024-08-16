using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<List<Admin>> GetAllAdmin()
        {
            return await _adminRepository.GetAllAdmin();
        }

        public async Task<Admin> GetAdminById(int adminId)
        {
            return await _adminRepository.GetAdminById(adminId);
        }

        public async Task<bool> CreateAdmin(Admin admin)
        {
            return await _adminRepository.CreateAdmin(admin);
        }

        public async Task<bool> UpdateAdmin(int id,Admin admin)
        {
            return await _adminRepository.UpdateAdmin(id,admin);
        }

        public async Task<bool> DeleteAdmin(int adminId)
        {
            return await _adminRepository.DeleteAdmin(adminId);
        }
    }


}

