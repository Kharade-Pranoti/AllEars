using AllEars.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Repositories
{
    public class BookAppointmentRepository : IBookAppointmentRepository
    {
        public async Task<List<BookAppointment>> GetAllAppointments()
        {
            using (var context = new AllEarsContext())
            {
                var appointments = from appt in context.BookAppointments
                                   select appt;
                return await appointments.ToListAsync();
            }
        }

        public async Task<BookAppointment> GetAppointmentById(int id)
        {
            using (var context = new AllEarsContext())
            {
                return await context.BookAppointments.FindAsync(id);
            }
        }

        public async Task<bool> CreateAppointment(BookAppointment appt)
        {
            using (var context = new AllEarsContext())
            {
                await context.BookAppointments.AddAsync(appt);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateAppointment(int id, BookAppointment appt)
        {
            using (var context = new AllEarsContext())
            {
                var existingAppt = await context.BookAppointments.FindAsync(id);
                if (existingAppt == null)
                {
                    return false; // Appointment not found
                }

                // Update properties
                existingAppt.patientId = appt.patientId;
                existingAppt.clinicalDoctorId = appt.clinicalDoctorId;
                existingAppt.appointment_date = appt.appointment_date;
                existingAppt.appointment_time = appt.appointment_time;
                // Update other properties as necessary

                context.BookAppointments.Update(existingAppt);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            using (var context = new AllEarsContext())
            {
                var appt = await context.BookAppointments.FindAsync(id);
                if (appt == null)
                {
                    return false; // Appointment not found
                }

                context.BookAppointments.Remove(appt);
                await context.SaveChangesAsync();
                return true; // Deletion successful
            }
        }
    }
}
