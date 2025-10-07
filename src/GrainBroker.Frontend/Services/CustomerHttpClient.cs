using System.Net.Http.Json;
using GrainBroker.Entities;
using GrainBroker.Entities.DTOs;

namespace GrainBroker.Frontend.Services
{
    public class CustomerHttpClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/Customer";

        public CustomerHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>(BaseUrl) ?? Enumerable.Empty<Customer>();
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"{BaseUrl}/{id}");
        }

        public async Task<Customer?> CreateCustomerAsync(CreateCustomerRequest request)
        {
            var customer = new Customer
            {
                CustomerName = request.CustomerName,
                CustomerLocation = request.Location,
                Status = "Active"
            };
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, customer);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Customer>();
        }

        public async Task<bool> UpdateCustomerAsync(Guid id, Customer customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", customer);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCustomerAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}