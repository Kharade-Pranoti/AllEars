using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using AllEars.Server.Services;

public class AuthService : IAuthService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IPatientRepository _patientRepository;

    public AuthService(IAdminRepository adminRepository, IPatientRepository patientRepository)
    {
        _adminRepository = adminRepository;
        _patientRepository = patientRepository;
    }

    public async Task<object> AuthenticateAsync(Login login)
    {
        // Check for admin first
        var admin = await _adminRepository.GetAdminByEmailAndPassword(login.Email, login.Password);
        if (admin != null)
        {
            Console.WriteLine("admin user");
            return new { Role = "Admin", User = admin };
        }

        // Check for patient if admin not found
        var patient = await _patientRepository.GetPatientByEmailAndPassword(login.Email, login.Password);
        if (patient != null)
        {
            Console.WriteLine("patient user");
            return new { Role = "Patient", User = patient };
        }

        // Return null if neither admin nor patient is found
        return null;
    }
}
