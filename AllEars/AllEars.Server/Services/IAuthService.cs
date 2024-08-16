using AllEars.Server.Entities;

namespace AllEars.Server.Services
{
    public interface IAuthService
    {
        Task<object> AuthenticateAsync(Login login);
    }
}
