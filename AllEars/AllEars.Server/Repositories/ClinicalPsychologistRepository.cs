using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
    public class ClinicalPsychologistRepository : IClinicalPsychologistRepository
    {
        public async Task<List<ClinicalPsychologist>> GetAllClinicalPsychologists()
        {
            using (var context = new AllEarsContext())
            {
                var clinicalPsychologists = from psychologist in context.ClinicalPsychologists
                                            select psychologist;
                return await clinicalPsychologists.ToListAsync();
            }
        }

        public async Task<ClinicalPsychologist> GetClinicalPsychologistById(int clinicalPsychologistId)
        {
            using (var context = new AllEarsContext())
            {
                var clinicalPsychologist = await context.ClinicalPsychologists.FindAsync(clinicalPsychologistId);

                // Optionally handle the case where clinicalPsychologist is not found
                if (clinicalPsychologist == null)
                {
                    return null;
                }

                return clinicalPsychologist;
            }
        }

        public async Task<bool> CreateClinicalPsychologist(ClinicalPsychologist clinicalPsychologist)
        {
            using (var context = new AllEarsContext())
            {
                await context.ClinicalPsychologists.AddAsync(clinicalPsychologist);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateClinicalPsychologist(int id, ClinicalPsychologist clinicalPsychologist)
        {
            using (var context = new AllEarsContext())
            {
                var existingClinicalPsychologist = await context.ClinicalPsychologists.FindAsync(id);
                if (existingClinicalPsychologist == null)
                {
                    return false; // Or throw an exception if not found
                }

                existingClinicalPsychologist.clinicalDoctor_name = clinicalPsychologist.clinicalDoctor_name;
                existingClinicalPsychologist.clinicalDoctor_email = clinicalPsychologist.clinicalDoctor_email;
                existingClinicalPsychologist.clinicalDoctor_password = clinicalPsychologist.clinicalDoctor_password;
                existingClinicalPsychologist.clinicalDoctor_specialization = clinicalPsychologist.clinicalDoctor_specialization;
                existingClinicalPsychologist.clinicalDoctor_qualification = clinicalPsychologist.clinicalDoctor_qualification;
                existingClinicalPsychologist.category_id = clinicalPsychologist.category_id;
                existingClinicalPsychologist.address = clinicalPsychologist.address;
                existingClinicalPsychologist.imagedata = clinicalPsychologist.imagedata;

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteClinicalPsychologist(int clinicalPsychologistId)
        {
            using (var context = new AllEarsContext())
            {
                var clinicalPsychologist = await context.ClinicalPsychologists.FindAsync(clinicalPsychologistId);
                if (clinicalPsychologist == null)
                {
                    return false; // Clinical Psychologist not found, return false
                }

                context.ClinicalPsychologists.Remove(clinicalPsychologist);
                await context.SaveChangesAsync();
                return true; // Deletion successful
            }
        }
    }
}
