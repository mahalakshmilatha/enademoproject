using GrainBroker.Entities;

namespace GrainBroker.API.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
    }
}