using AllEars.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Repositories
{
    public class CounsellingDoctorAvailabilityRepository : ICounsellingDoctorAvailabilityRepository
    {
        public async Task<List<CounsellingDoctorAvailability>> GetAll()
        {
            using (var context = new AllEarsContext())
            {
                var availabilities = from availability in context.CounsellingDoctorAvailabilities
                                     select availability;
                return await availabilities.ToListAsync();
            }
        }

        public async Task<CounsellingDoctorAvailability> GetById(int id)
        {
            using (var context = new AllEarsContext())
            {
                var availability = await context.CounsellingDoctorAvailabilities.FindAsync(id);

                // Optionally handle the case where the record is not found
                if (availability == null)
                {
                    return null;
                }

                return availability;
            }
        }

        public async Task<bool> Create(CounsellingDoctorAvailability co_avail)
        {
            using (var context = new AllEarsContext())
            {
                await context.CounsellingDoctorAvailabilities.AddAsync(co_avail);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Update(int id, CounsellingDoctorAvailability co_avail)
        {
            using (var context = new AllEarsContext())
            {
                var existingAvailability = await context.CounsellingDoctorAvailabilities.FindAsync(id);
                if (existingAvailability == null)
                {
                    return false; // Record not found
                }

                // Update the existing record
                existingAvailability.therapistId = co_avail.therapistId;
                existingAvailability.co_available_date = co_avail.co_available_date;
                existingAvailability.session_start_time = co_avail.session_start_time;
                existingAvailability.session_end_time = co_avail.session_end_time;

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var context = new AllEarsContext())
            {
                var availability = await context.CounsellingDoctorAvailabilities.FindAsync(id);
                if (availability == null)
                {
                    return false; // Record not found
                }

                context.CounsellingDoctorAvailabilities.Remove(availability);
                await context.SaveChangesAsync();
                return true; // Deletion successful
            }
        }
    }
}
