using GrainBroker.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrainBroker.API.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly GrainBrokerDbContext _context;

        public SupplierService(GrainBrokerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
    }
}