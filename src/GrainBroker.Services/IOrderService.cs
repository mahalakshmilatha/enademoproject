using GrainBroker.Entities;

namespace GrainBroker.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Guid customerId, decimal requestedGrainAmount);
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    }
}