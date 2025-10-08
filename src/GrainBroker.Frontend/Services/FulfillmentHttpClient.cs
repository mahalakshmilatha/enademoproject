using System.Net.Http.Json;
using GrainBroker.Entities;
using GrainBroker.Entities.DTOs;

namespace GrainBroker.Frontend.Services
{
    public class FulfillmentHttpClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/Fulfillment";

        public FulfillmentHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderFulfillment>> GetAllFulfillmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OrderFulfillment>>(BaseUrl) ?? Enumerable.Empty<OrderFulfillment>();
        }

        public async Task<OrderFulfillment?> GetFulfillmentByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<OrderFulfillment>($"{BaseUrl}/{id}");
        }

        public async Task<OrderFulfillment?> CreateFulfillmentAsync(CreateFulfillmentRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<OrderFulfillment>();
        }

        public async Task<bool> UpdateFulfillmentAsync(Guid id, OrderFulfillment fulfillment)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", fulfillment);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteFulfillmentAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<OrderFulfillment>> GetFulfillmentsByOrderIdAsync(Guid orderId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OrderFulfillment>>($"{BaseUrl}/order/{orderId}") 
                ?? Enumerable.Empty<OrderFulfillment>();
        }

        public async Task<IEnumerable<Supplier>> FindSuitableSuppliersAsync(Guid orderId)
        {
            var request = new FindSuppliersForOrderRequest { OrderId = orderId };
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/find-suppliers", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Supplier>>() ?? Enumerable.Empty<Supplier>();
        }
    }
}