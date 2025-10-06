using GrainBroker.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrainBroker.Services
{
    public class FulfillmentService : IFulfillmentService
    {
        private readonly GrainBrokerDbContext _context;

        public FulfillmentService(GrainBrokerDbContext context)
        {
            _context = context;
        }

        public async Task<OrderFulfillment> CreateFulfillmentAsync(Guid orderId, Guid supplierId, decimal suppliedAmount, decimal costOfDelivery)
        {
            // Verify order exists
            var order = await _context.Orders.FindAsync(orderId)
                ?? throw new ArgumentException("Order not found", nameof(orderId));

            // Verify supplier exists
            var supplier = await _context.Suppliers.FindAsync(supplierId)
                ?? throw new ArgumentException("Supplier not found", nameof(supplierId));

            // Check if fulfillment already exists for this order
            var existingFulfillment = await _context.Set<OrderFulfillment>()
                .FirstOrDefaultAsync(f => f.OrderId == orderId);

            if (existingFulfillment != null)
            {
                throw new InvalidOperationException("Order already has a fulfillment");
            }

            var fulfillment = new OrderFulfillment
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                SupplierId = supplierId,
                SuppliedAmount = suppliedAmount,
                CostOfDelivery = costOfDelivery
            };

            _context.Set<OrderFulfillment>().Add(fulfillment);
            await _context.SaveChangesAsync();

            return fulfillment;
        }

        public async Task<OrderFulfillment?> GetFulfillmentByIdAsync(Guid id)
        {
            return await _context.Set<OrderFulfillment>()
                .Include(f => f.Order)
                .Include(f => f.Supplier)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<OrderFulfillment?> GetFulfillmentByOrderIdAsync(Guid orderId)
        {
            return await _context.Set<OrderFulfillment>()
                .Include(f => f.Order)
                .Include(f => f.Supplier)
                .FirstOrDefaultAsync(f => f.OrderId == orderId);
        }

        public async Task<IEnumerable<OrderFulfillment>> GetFulfillmentsBySupplierIdAsync(Guid supplierId)
        {
            return await _context.Set<OrderFulfillment>()
                .Include(f => f.Order)
                .Include(f => f.Supplier)
                .Where(f => f.SupplierId == supplierId)
                .ToListAsync();
        }
    }
}