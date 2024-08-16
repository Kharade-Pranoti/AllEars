using AllEars.Server.Entities;

namespace AllEars.Server.Repositories
{
    public interface IBillingRepository
    {
        Task<List<Billing>> GetAllBillings();
        Task<Billing> GetBillingById(int billingId);
        Task<bool> CreateBilling(Billing billing);
        Task<bool> UpdateBilling(int id, Billing billing);
        Task<bool> DeleteBilling(int billingId);
    }
}
