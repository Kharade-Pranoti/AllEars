using AllEars.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public async Task<Admin> GetAdminByEmailAndPassword(string email, string password)
        {
            using (var context = new AllEarsContext())
            {
                var admin = await context.Admins
                                         .FirstOrDefaultAsync(a => a.admin_email == email && a.admin_password == password);

                return admin;
            }
        }

        public async Task<List<Admin>> GetAllAdmin()
        {
            using (var context = new AllEarsContext())
            {
                var admins = from admin in context.Admins
                             select admin;
                return await admins.ToListAsync();
            }
        }

        public async Task<Admin> GetAdminById(int adminId)
        {
            using (var context = new AllEarsContext())
            {
                var admin = await context.Admins.FindAsync(adminId);

                // Optionally handle the case where admin is not found
                if (admin == null)
                {
                    return null;
                }

                return admin;
            }
        }


        public async Task<bool> CreateAdmin(Admin admin) 
        {
            using (var context = new AllEarsContext())
            {
                await context.Admins.AddAsync(admin);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateAdmin(int id, Admin admin)
        {
            using (var context = new AllEarsContext())
            {
                var adm = await context.Admins.FindAsync(id);
                if (adm == null)
                {
                    return false; // Or throw an exception if not found
                }

                adm.admin_name = admin.admin_name;
                adm.admin_password = admin.admin_password;
                adm.admin_email = admin.admin_email;

                await context.SaveChangesAsync();
                return true;

            }
        }

        public async Task<bool> DeleteAdmin(int adminId)
        {
            using (var context = new AllEarsContext())
            {
                var admin = await context.Admins.FindAsync(adminId);
                if (admin == null)
                {
                    return false; // Admin not found, return false 
                }

                context.Admins.Remove(admin);
                await context.SaveChangesAsync();
                return true; // Deletion successful
            }
        }

    }
}
