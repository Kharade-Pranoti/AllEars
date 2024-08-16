using AllEars.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        public async Task<List<Billing>> GetAllBillings()
        {
            using (var context = new AllEarsContext())
            {
                var billings = from billing in context.Billings
                               select billing;
                return await billings.ToListAsync();
            }
        }

        public async Task<Billing> GetBillingById(int billingId)
        {
            using (var context = new AllEarsContext())
            {
                var billing = await context.Billings.FindAsync(billingId);

                // Optionally handle the case where billing is not found
                if (billing == null)
                {
                    return null;
                }

                return billing;
            }
        }

        public async Task<bool> CreateBilling(Billing billing)
        {
            using (var context = new AllEarsContext())
            {
                await context.Billings.AddAsync(billing);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateBilling(int id, Billing billing)
        {
            using (var context = new AllEarsContext())
            {
                var existingBilling = await context.Billings.FindAsync(id);
                if (existingBilling == null)
                {
                    return false; // Or throw an exception if not found
                }

                existingBilling.patientId = billing.patientId;
                existingBilling.clinicalDoctorId = billing.clinicalDoctorId;
                existingBilling.appointment_id = billing.appointment_id;
                existingBilling.bill_price = billing.bill_price;
                existingBilling.paymentstatus = billing.paymentstatus;

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteBilling(int billingId)
        {
            using (var context = new AllEarsContext())
            {
                var billing = await context.Billings.FindAsync(billingId);
                if (billing == null)
                {
                    return false; // Billing not found, return false 
                }

                context.Billings.Remove(billing);
                await context.SaveChangesAsync();
                return true; // Deletion successful
            }
        }
    }
}
