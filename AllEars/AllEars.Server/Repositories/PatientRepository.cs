using AllEars.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public async Task<List<Patient>> GetAllPatient()
        {
            using (var context = new AllEarsContext())
            {
                var patients = from patient in context.Patients
                               select patient;
                return await patients.ToListAsync();
            }
        }

        public async Task<Patient> GetPatientById(int patientId)
        {
            using (var context = new AllEarsContext())
            {
                var patient = await context.Patients.FindAsync(patientId);

                // Optionally handle the case where patient is not found
                if (patient == null)
                {
                    return null;
                }

                return patient;
            }
        }

        public async Task<Patient> GetPatientByEmailAndPassword(string email,string password)
        {
            using (var context = new AllEarsContext())
            {
                var patient = await context.Patients.FirstOrDefaultAsync(a => a.patient_email == email && a.patient_password == password);

                return patient;
            }
        }
        
        public async Task<bool> Insert(Patient patient)
        {
            using (var context = new AllEarsContext())
            {
                await context.Patients.AddAsync(patient);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Update(int patientId, Patient patient)
        {
            using (var context = new AllEarsContext())
            {
                var existingPatient = await context.Patients.FindAsync(patientId);
                if (existingPatient == null)
                {
                    return false; // Patient not found
                }

                existingPatient.patient_name = patient.patient_name;
                existingPatient.patient_email = patient.patient_email;
                existingPatient.patient_password = patient.patient_password;
                existingPatient.patient_gender = patient.patient_gender;
                existingPatient.patient_age= patient.patient_age;
                existingPatient.patient_bloodGroup= patient.patient_bloodGroup;
                existingPatient.address = patient.address;
                existingPatient.category_id=patient.category_id;

               
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(int patientId)
        {
            using (var context = new AllEarsContext())
            {
                var patient = await context.Patients.FindAsync(patientId);
                if (patient == null)
                {
                    return false; // Patient not found
                }

                context.Patients.Remove(patient);
                await context.SaveChangesAsync();
                return true; // Deletion successful
            }
        }
    }
}
