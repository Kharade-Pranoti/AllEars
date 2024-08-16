using AllEars.Server.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace AllEars.Server.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AllEarsContext _context;

        public AuthRepository(AllEarsContext context)
        {
            _context = context;
        }

        public async Task<Login> Login(string email, string password)
        {
            return await _context.Logins.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
