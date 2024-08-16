using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
        public class CounsellingPsychologistRepository : ICounsellingPsychologistRepository
        {
            public async Task<List<CounsellingPsychologist>> GetAllCounsellingPsychologists()
            {
                using (var context = new AllEarsContext())
                {
                    var counsellingPsychologists = from psychologist in context.CounsellingPsychologists
                                                   select psychologist;
                    return await counsellingPsychologists.ToListAsync();
                }
            }

            public async Task<CounsellingPsychologist> GetCounsellingPsychologistById(int counsellingPsychologistId)
            {
                using (var context = new AllEarsContext())
                {
                    var counsellingPsychologist = await context.CounsellingPsychologists.FindAsync(counsellingPsychologistId);

                    // Optionally handle the case where counsellingPsychologist is not found
                    if (counsellingPsychologist == null)
                    {
                        return null;
                    }

                    return counsellingPsychologist;
                }
            }

            public async Task<bool> CreateCounsellingPsychologist(CounsellingPsychologist counsellingPsychologist)
            {
                using (var context = new AllEarsContext())
                {
                    await context.CounsellingPsychologists.AddAsync(counsellingPsychologist);
                    await context.SaveChangesAsync();
                    return true;
                }
            }

            public async Task<bool> UpdateCounsellingPsychologist(int id, CounsellingPsychologist counsellingPsychologist)
            {
                using (var context = new AllEarsContext())
                {
                    var existingCounsellingPsychologist = await context.CounsellingPsychologists.FindAsync(id);
                    if (existingCounsellingPsychologist == null)
                    {
                        return false; // Or throw an exception if not found
                    }

                existingCounsellingPsychologist.counsellingDoctor_name = counsellingPsychologist.counsellingDoctor_name;
                existingCounsellingPsychologist.counsellingDoctor_email = counsellingPsychologist.counsellingDoctor_email;
                existingCounsellingPsychologist.counsellingDoctor_password = counsellingPsychologist.counsellingDoctor_password;
                existingCounsellingPsychologist.counsellingDoctor_specialization = counsellingPsychologist.counsellingDoctor_specialization;
                existingCounsellingPsychologist.counsellingDoctor_qualification = counsellingPsychologist.counsellingDoctor_qualification;
                existingCounsellingPsychologist.category_id = counsellingPsychologist.category_id;

                await context.SaveChangesAsync();
                    return true;
                }
            }

            public async Task<bool> DeleteCounsellingPsychologist(int counsellingPsychologistId)
            {
                using (var context = new AllEarsContext())
                {
                    var counsellingPsychologist = await context.CounsellingPsychologists.FindAsync(counsellingPsychologistId);
                    if (counsellingPsychologist == null)
                    {
                        return false; // Counselling Psychologist not found, return false
                    }

                    context.CounsellingPsychologists.Remove(counsellingPsychologist);
                    await context.SaveChangesAsync();
                    return true; // Deletion successful
                }
            }
        }
}

