using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public class BookAppointmentService : IBookAppointmentService
    {
        private readonly IBookAppointmentRepository _bookAppointmentRepository;

        public BookAppointmentService(IBookAppointmentRepository bookAppointmentRepository)
        {
            _bookAppointmentRepository = bookAppointmentRepository;
        }

        public async Task<List<BookAppointment>> GetAllAppointments()
        {
            return await _bookAppointmentRepository.GetAllAppointments();
        }

        public async Task<BookAppointment> GetAppointmentById(int id)
        {
            return await _bookAppointmentRepository.GetAppointmentById(id);
        }

        public async Task<bool> CreateAppointment(BookAppointment appt)
        {
            return await _bookAppointmentRepository.CreateAppointment(appt);
        }

        public async Task<bool> UpdateAppointment(int id, BookAppointment appt)
        {
            return await _bookAppointmentRepository.UpdateAppointment(id, appt);
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            return await _bookAppointmentRepository.DeleteAppointment(id);
        }
    }
}
