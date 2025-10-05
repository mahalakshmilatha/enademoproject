using GrainBroker.Entities;

namespace GrainBroker.API.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(Guid id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer?> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(Guid id);
    }
}