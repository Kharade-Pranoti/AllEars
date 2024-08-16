using AllEars.Server.Entities;
using AllEars.Server.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllEars.Server.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;

        public BillingService(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public async Task<List<Billing>> GetAllBillings()
        {
            return await _billingRepository.GetAllBillings();
        }

        public async Task<Billing> GetBillingById(int billingId)
        {
            return await _billingRepository.GetBillingById(billingId);
        }

        public async Task<bool> CreateBilling(Billing billing)
        {
            return await _billingRepository.CreateBilling(billing);
        }

        public async Task<bool> UpdateBilling(int id, Billing billing)
        {
            return await _billingRepository.UpdateBilling(id, billing);
        }

        public async Task<bool> DeleteBilling(int billingId)
        {
            return await _billingRepository.DeleteBilling(billingId);
        }
    }
}
