using System.Net.Http.Json;
using GrainBroker.Entities;
using GrainBroker.Entities.DTOs;

namespace GrainBroker.Frontend.Services
{
    public interface IFulfillmentService
    {
        Task<IEnumerable<Supplier>?> FindSuitableSuppliersAsync(Guid orderId);
    }

    public class FulfillmentService : IFulfillmentService
    {
        private readonly HttpClient _httpClient;

        public FulfillmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Supplier>?> FindSuitableSuppliersAsync(Guid orderId)
        {
            var request = new FindSuppliersForOrderRequest { OrderId = orderId };
            var response = await _httpClient.PostAsJsonAsync("api/fulfillment/find-suppliers", request);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Supplier>>();
            }

            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}