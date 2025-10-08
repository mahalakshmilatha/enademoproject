using GrainBroker.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrainBroker.Services
{
    public class OrderService : IOrderService
    {
        private readonly GrainBrokerDbContext _context;

        public OrderService(GrainBrokerDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Guid customerId, decimal requestedGrainAmount)
        {
            var customer = await _context.Customers.FindAsync(customerId)
                ?? throw new ArgumentException("Customer not found", nameof(customerId));

            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                RequestedGrainAmount = requestedGrainAmount
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                //.Include(o => o.Fulfillment)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}