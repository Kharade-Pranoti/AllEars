using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
    public interface IAuthRepository
    {
        Task<Login> Login(string email, string password);
    }
}
