using GrainBroker.Entities;

namespace GrainBroker.Services
{
    public interface IFulfillmentService
    {
        Task<OrderFulfillment> CreateFulfillmentAsync(Guid orderId, Guid supplierId, decimal suppliedAmount, decimal costOfDelivery);
        Task<OrderFulfillment?> GetFulfillmentByIdAsync(Guid id);
        Task<OrderFulfillment?> GetFulfillmentByOrderIdAsync(Guid orderId);
        Task<IEnumerable<OrderFulfillment>> GetFulfillmentsBySupplierIdAsync(Guid supplierId);
        Task<IEnumerable<Supplier>> FindSuitableSuppliersForOrderAsync(Guid orderId);
    }
}