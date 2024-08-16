using AllEars.Server.Entities;

namespace AllEars.Server.Services
{
    public interface IBookAppointmentService
    {
        Task<List<BookAppointment>> GetAllAppointments();
        Task<BookAppointment> GetAppointmentById(int id);
        Task<bool> CreateAppointment(BookAppointment appt);
        Task<bool> UpdateAppointment(int id, BookAppointment appt);
        Task<bool> DeleteAppointment(int id);
    }
}
