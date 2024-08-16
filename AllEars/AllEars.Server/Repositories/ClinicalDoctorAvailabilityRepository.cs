using AllEars.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Repositories
{
    public class ClinicalDoctorAvailabilityRepository : IClinicalDoctorAvailabilityRepository
    {
        public async Task<List<ClinicalDoctorAvailability>> GetAll()
        {
            using (var context = new AllEarsContext())
            {
                var availabilities = from availability in context.ClinicalDoctorAvailabilities
                                     select availability;
                return await availabilities.ToListAsync();
            }
        }

        public async Task<ClinicalDoctorAvailability> GetById(int id)
        {
            using (var context = new AllEarsContext())
            {
                var availability = await context.ClinicalDoctorAvailabilities.FindAsync(id);

                // Optionally handle the case where availability is not found
                if (availability == null)
                {
                    return null;
                }

                return availability;
            }
        }

        public async Task<bool> Create(ClinicalDoctorAvailability clAvail)
        {
            using (var context = new AllEarsContext())
            {
                await context.ClinicalDoctorAvailabilities.AddAsync(clAvail);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Update(int id, ClinicalDoctorAvailability clAvail)
        {
            using (var context = new AllEarsContext())
            {
                var existingAvailability = await context.ClinicalDoctorAvailabilities.FindAsync(id);
                if (existingAvailability == null)
                {
                    return false; // Availability not found
                }

                existingAvailability.doctorId = clAvail.doctorId;
                existingAvailability.cl_available_date = clAvail.cl_available_date;
                existingAvailability.start_time = clAvail.start_time;
                existingAvailability.end_time = clAvail.end_time;

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var context = new AllEarsContext())
            {
                var availability = await context.ClinicalDoctorAvailabilities.FindAsync(id);
                if (availability == null)
                {
                    return false; // Availability not found
                }

                context.ClinicalDoctorAvailabilities.Remove(availability);
                await context.SaveChangesAsync();
                return true; // Deletion successful
            }
        }
    }
}
